using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Chests", fileName = "Chest")]
public class ChestData : ItemData
{
    public int ArmorKoof;
    public float Weight;
    public List<ItemBehaviour> behaviours;
}
