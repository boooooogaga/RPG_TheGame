using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Sword", fileName = "Sword")]
public class SwordData : ItemData
{
    public float damage;
    public float attackSpeed;
    public float attackDelay;
    public List<ItemBehaviour> behaviours;
}
