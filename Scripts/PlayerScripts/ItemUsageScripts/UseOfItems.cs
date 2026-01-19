using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class UseOfItems : MonoBehaviour
{
    public IUsable itemInHand;
    private Sword sword;
    private Poison poison;
    [SerializeField] private Image ArmFov;
    private void Start()
    {
        poison = GetComponent<Poison>();
        sword = GetComponent<Sword>();
        Equip(sword);
    }
    public void Equip(IUsable item)
    {
        itemInHand = item; 
        ArmFov.sprite = itemInHand.GetFovSprite();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            itemInHand?.Use();
        if (Input.GetKeyDown("f"))
        {
            Equip(poison);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            sword.EquipSword();
            Equip(sword);
        }
       
    }
   
}