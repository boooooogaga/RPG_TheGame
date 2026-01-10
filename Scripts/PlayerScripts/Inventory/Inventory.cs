using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SwordData[] Swords = new SwordData[3];
    public ChestData currentChest;
    public PoisonData currentPoison;

    public void AddItem(ItemData item)
    {
        if (item is SwordData sword)
        {
            return;
        }
        if (item is PoisonData poison)
        {
            return;
        }
        if (item is ChestData chest)
        {
            return;
        }
    }
}
