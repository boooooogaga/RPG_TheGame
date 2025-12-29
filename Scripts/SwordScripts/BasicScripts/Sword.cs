using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sword : MonoBehaviour, IUsable
{
    BoxCollider attackCollider;
    [Header("Inventory")]
    private Inventory inventory;
    [SerializeField] GameObject Player;

    Animator anim;
    AudioSource PlayerAudio;
    public SwordData currentSword; // текущие данные меча либо же обьект меча (Scriptbleobject)

    private bool canAttack = true;

    public SwordData[] Swords = new SwordData[3];

    private void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
        attackCollider = GetComponent<BoxCollider>();
        attackCollider.enabled = false;
        inventory = gameObject.GetComponent<Inventory>();
        anim = GetComponent<Animator>();
    }
    public void Attack() // просто функция которая вызывает коротину
    {
        if (!canAttack) return;
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine() // основная корутина для атаки
    {
        canAttack = false;
        yield return new WaitForSeconds(currentSword.attackDelay);

        foreach (var behaviour in currentSword.behaviours)
            behaviour.OnUsePlayerEffect(Player);

        PlayerAudio.PlayOneShot(currentSword.UsageSound);
        
        Debug.Log($"Атака мечом: {currentSword.Name}");
        attackCollider.enabled = true;

        // Задержка между ударами
        yield return new WaitForSeconds(currentSword.attackSpeed);
        attackCollider.enabled = false;
        canAttack = true;
    }

    public void EquipSwordSlot(SwordData newSword) 
    {
        currentSword = newSword;
        Debug.Log($"Экипирован меч: {newSword.Name}");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
    public Sprite GetFovSprite() //для прогрузки спрайта в руке в скрипте "UseOfItems"
    {
        return currentSword.FovSprite;
    }
    public void Use() //для испозьзования предметов в руке
    {
        Attack();
    }
    public void SwordSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { EquipSwordSlot(Swords[0]); GetFovSprite(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { EquipSwordSlot(Swords[1]); GetFovSprite(); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { EquipSwordSlot(Swords[2]); GetFovSprite(); }
    }
    void Update()
    {
        Swords = inventory.Swords;
    }
}