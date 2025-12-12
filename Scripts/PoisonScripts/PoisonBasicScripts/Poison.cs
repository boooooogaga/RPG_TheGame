using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour, IUsable
{
    public PoisonData currentPoison;
    private int HP = 10;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Use()
    {
        HP++;
        Debug.Log("Выпил зелье");
    }
    public Sprite GetFovSprite()
    {
        return currentPoison.FovSprite;
    }
    
}
