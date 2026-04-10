using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyData : MonoBehaviour
{
    public float HPMax;
    public float TemporaryHealth;
    public float CurrentHealth;
    public float ManaMax;
    public float TemporaryMana;
    public float CurrentMana;
    public float Strength;
    public float Dexterity;
    public float Itelligence;
    public int lvl;

    public void Start()
    {
        CurrentHealth = HPMax;
        CurrentMana = ManaMax;
    }
    public void TakeDamage(float Damage)
    {
         CurrentHealth -= Damage;
         if (gameObject.tag == "Player")
         {
             Camera.main?.GetComponent<CameraBehaviour>()?.CameraShake(0.5f, 0.3f, 1f);
         }
    }
    public void BurnMana(float Burn)
    {
         CurrentMana -= Burn;
    }
}
