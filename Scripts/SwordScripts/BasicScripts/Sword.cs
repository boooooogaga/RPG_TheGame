using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sword : MonoBehaviour, IUsable
{
    public Animator AnimForRightArm;
    BoxCollider attackCollider;
    [Header("Inventory")]
    private Inventory inventory;
    [SerializeField] GameObject Player;
    BodyData EnemyBody;
    Animator anim;
    AudioSource PlayerAudio;
    public SwordData currentSword; // ������� ������ ���� ���� �� ������ ���� (Scriptbleobject)

    private bool canAttack = true;
    private bool canSwap = true;
    public int currentSlot = 1;
    public SwordData[] Swords = new SwordData[3];

    private void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
        attackCollider = GetComponentInChildren<BoxCollider>();
        attackCollider.enabled = false;
        inventory = gameObject.GetComponent<Inventory>();
        anim = GetComponent<Animator>();
    }
    public void Attack() // ������ ������� ������� �������� ��������
    {
        if (!canAttack) return;
        StartCoroutine(AttackRoutine());
        AnimForRightArm.SetTrigger("Attack");
}

    private IEnumerator AttackRoutine() // �������� �������� ��� �����
    {
        canAttack = false;
        canSwap = false;
        yield return new WaitForSeconds(currentSword.attackDelay);

        foreach (var behaviour in currentSword.behaviours)
            behaviour.OnUsePlayerEffect(Player);

        PlayerAudio.PlayOneShot(currentSword.UsageSound);
        
        Debug.Log($"����� �����: {currentSword.Name}");
        attackCollider.enabled = true;

        // �������� ����� �������
        yield return new WaitForSeconds(currentSword.attackSpeed);
        attackCollider.enabled = false;
        canAttack = true;
        canSwap = true;
    }

    public void EquipSwordSlot(SwordData newSword) 
    {
        currentSword = newSword;
        Debug.Log($"���������� ���: {newSword.Name}");
    }
    public void ProcessTrigger(string zoneName,Collider other) 
    {
        if (other.CompareTag("Enemy")) 
        {
            Debug.Log("Враг попал в зону:");
            EnemyBody = other.GetComponent<BodyData>();
            if(EnemyBody != null) EnemyBody.TakeDamage(50);
            Destroy(other.gameObject);
        }
}    public Sprite GetFovSprite() //��� ��������� ������� � ���� � ������� "UseOfItems"
    {
        return currentSword.FovSprite;
    }
    public void Use() //��� ������������� ��������� � ����
    {
        Attack();
    }
    private IEnumerator SwordSwap()
    {
        if (canSwap)
        {
            canSwap = false;
            canAttack = false;

            if (Input.GetKeyDown(KeyCode.Alpha1) && currentSlot != 1) { EquipSwordSlot(Swords[0]); GetFovSprite(); currentSlot = 1; AnimForRightArm.Play("RightArmEquipSword", 0, 0f); }
                else if(Input.GetKeyDown(KeyCode.Alpha2) && currentSlot != 2) { EquipSwordSlot(Swords[1]); GetFovSprite(); currentSlot = 2; AnimForRightArm.Play("RightArmEquipSword", 0, 0f); }
                else if(Input.GetKeyDown(KeyCode.Alpha3) && currentSlot != 3) { EquipSwordSlot(Swords[2]); GetFovSprite(); currentSlot = 3; AnimForRightArm.Play("RightArmEquipSword", 0, 0f); }

                yield return new WaitForSeconds(1);
            canAttack = true;
            canSwap = true;
        }
    }
    public void EquipSword() { StartCoroutine(SwordSwap()); }
    void Update()
    {
        Swords = inventory.Swords;
    }
}