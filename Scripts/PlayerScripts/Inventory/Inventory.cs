using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SwordData[] Swords = new SwordData[3];
    public ChestData currentChest;
    public PoisonData currentPoison;

    public void AddSword(SwordData sword)
    {
        for (int i = 0; i < Swords.Length;  i++)
        {
            if (Swords[i] == null) Swords[i] = sword;
        }
    }
    public void AddChest(ChestData chest)
    {
        if (currentChest == null) currentChest = chest;
        else { Instantiate(currentChest.worldPrefab, transform.position + transform.forward, Quaternion.identity);
               currentChest = chest;
        }
    }
}
