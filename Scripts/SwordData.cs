using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Sword", fileName = "Sword")]
public class SwordData : ScriptableObject
{
    public string swordName;
    public float damage;
    public float attackSpeed;
    public float attackDelay;
    public Sprite swordSprite; // UI-������ ����
    public AudioClip attackSound; // ���� �����
}
