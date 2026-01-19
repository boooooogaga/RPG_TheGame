using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject // общий класс для предметов
{
    public string Name;
    public string Description;
    public int Rarity;
    public AnimationClip EquipAnimation;
    public AnimationClip UsageAnimation;
    public Sprite InventorySprite; // UI-спрайт для инвентаря
    public Sprite FovSprite;  // UI-спрайт для вида с руки, либо для иконки если это снаряга
    public AudioClip UsageSound; // звук использования
    public AudioClip EquipSound;
}
