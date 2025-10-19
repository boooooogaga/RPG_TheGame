using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Sword", fileName = "Sword")]
public class SwordData : ScriptableObject
{
    public int id;
    public float  damage, weight, knockback, attackDelay, attackTime;
    public string Name, description;
    public Sprite icon;
}
