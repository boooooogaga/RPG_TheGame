using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{

    BoxCollider attackCollider;

    Animator anim;

    [Header("UI Components")]
    public Image swordUIImage; // картинка меча на экране

    [Header("Sword Settings")]
    public SwordData currentSword; // текущие данные меча

    private bool canAttack = true;

    private void Start()
    {
        attackCollider = GetComponent<BoxCollider>();
        attackCollider.enabled = false;

        anim = GetComponent<Animator>();
    }
    public void Attack()
    {
        if (!canAttack) return;
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        canAttack = false;
        if (!canAttack)
        {
            anim.SetBool("Swing", true);
        }
        else
        {
            anim.SetBool("Swing", false);
        }

        yield return new WaitForSeconds(currentSword.attackDelay);
       
        Debug.Log($"Атака мечом: {currentSword.swordName}");
        attackCollider.enabled = true;

        // Задержка между ударами
        yield return new WaitForSeconds(currentSword.attackSpeed);
        attackCollider.enabled = false;
        canAttack = true;
    }

    public void Equip(SwordData newSword)
    {
        currentSword = newSword;
        swordUIImage.sprite = newSword.swordSprite;
        Debug.Log($"Экипирован меч: {newSword.swordName}");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}