using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sword : MonoBehaviour, IUsable
{
    BoxCollider attackCollider;

    [SerializeField] GameObject Player;

    Animator anim;

    [Header("Sword Settings")]
    public SwordData currentSword; // текущие данные меча либо же обьект меча (Scriptbleobject)

    private bool canAttack = true;

    private void Start()
    {

        attackCollider = GetComponent<BoxCollider>();
        attackCollider.enabled = false;

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
        
        Debug.Log($"Атака мечом: {currentSword.Name}");
        attackCollider.enabled = true;

        // Задержка между ударами
        yield return new WaitForSeconds(currentSword.attackSpeed);
        attackCollider.enabled = false;
        canAttack = true;
    }

    public void Equip(SwordData newSword) 
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
}