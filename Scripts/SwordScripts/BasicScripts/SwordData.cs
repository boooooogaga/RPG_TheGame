using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Sword", fileName = "Sword")]
public class SwordData : ItemData // тут ничего писать не нужно, класс для создания мечей через скриптбл обджект
{
    public float damage;
    public float attackSpeed;
    public float attackDelay;
    public List<ItemBehaviour> behaviours; // сюда кидаем все способности через испектор скриптами
}
