using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    Sword sword;
    Inventory inventory;
    [SerializeField] public Image Compass;
    [SerializeField] public GameObject Player;
     public GameObject[] InventorySlots = new GameObject[3];
     public Image[] SwordItems = new Image[3];

    void Start()
    {
        inventory = Player.GetComponent<Inventory>();
        sword = Player.GetComponent<Sword>();
    }
    private void Update()
    {
        float playerY = Player.transform.eulerAngles.y;
        Compass.transform.rotation = Quaternion.Euler(0f, 0f, -playerY);
        for(int i = 0; i < InventorySlots.Length; i++)
        {
            GameObject SlotSprite = InventorySlots[i];
            SlotSprite.SetActive(false);
            if(i + 1 == sword.currentSlot)
            {
                SlotSprite.SetActive(true);
            }
        }
        for(int i = 0; i < SwordItems.Length; i++)
        {
            SwordItems[i].sprite = inventory.Swords[i].InventorySprite;
        }
    }
}
