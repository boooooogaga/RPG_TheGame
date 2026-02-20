using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyData : MonoBehaviour
{
    public int HPMax;
    public int TemporaryHealth;
    public int CurrentHealth;
    public int ManaMax;
    public int TemporaryMana;
    public int CurrentMana;
    public int Strength;
    public int Dexterity;
    public int Itelligence;
    public int lvl;

    public void Start()
    {
        CurrentHealth = HPMax;
        CurrentMana = ManaMax;
    }
    public void TakeDamage(int Damage)
    {
         CurrentHealth -= Damage;
    }
    public void BurnMana(int Burn)
    {
         CurrentMana -= Burn;
    }
}
