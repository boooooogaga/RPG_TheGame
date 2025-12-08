using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite InventorySprite; // UI-спрайт для инвентаря
    public Sprite FovSprite;  // UI-спрайт для вида с руки 
    public AudioClip UsageSound; // звук использования
    public virtual void Use(GameObject player) { }
}
