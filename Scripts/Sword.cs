using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{

    BoxCollider attackCollider;


    [Header("UI Components")]
    public Image swordUIImage; // �������� ���� �� ������

    [Header("Sword Settings")]
    public SwordData currentSword; // ������� ������ ����

    private bool canAttack = true;

    private void Start()
    {
        attackCollider = GetComponent<BoxCollider>();
        attackCollider.enabled = false;
    }
    public void Attack()
    {
        if (!canAttack) return;
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        canAttack = false;

        yield return new WaitForSeconds(currentSword.attackDelay);
        Debug.Log($"����� �����: {currentSword.swordName}");
        attackCollider.enabled = true;

        // �������� ����� �������
        yield return new WaitForSeconds(currentSword.attackSpeed);
        attackCollider.enabled = false;
        canAttack = true;
    }

    public void Equip(SwordData newSword)
    {
        currentSword = newSword;
        swordUIImage.sprite = newSword.swordSprite;
        Debug.Log($"���������� ���: {newSword.swordName}");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
