using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Sword", fileName = "Sword")]
public class SwordData : ScriptableObject
{
    public float cost, damage, weight, knockback;
    public string Name, description;
    public Sprite icon;

    public virtual void Attack() {
        //сюда вставить анимацию
    }

    public virtual void SpecialAbilities() { }
}
