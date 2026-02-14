using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyData : MonoBehaviour
{
    public int HPMax;
    public int TemporaryHealth;
    public int CurrenHealth;
    public int Strength;
    public int Dexterity;
    public int Itelligence;
    public int lvl;

    public void Start()
    {
        CurrenHealth = HPMax;
    }
    public void TakeDamage(int Damage)
    {
         CurrenHealth -= Damage;
    }
}
