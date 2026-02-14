using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    BodyData body;
    Sword sword;
    Inventory inventory;
    public int HPUpdateSpeed;
    [SerializeField] public Image Compass;
    [SerializeField] public Image HPbar;
    [SerializeField] public Image HPbarEffect;
    [SerializeField] public GameObject Player;
     public GameObject[] InventorySlots = new GameObject[3];
     public Image[] SwordItems = new Image[3];

    void Start()
    {
        inventory = Player.GetComponent<Inventory>();
        sword = Player.GetComponent<Sword>();
        body = Player.GetComponent<BodyData>();
    }
    private void Update()
    {
        float playerY = Player.transform.eulerAngles.y;
        Compass.transform.rotation = Quaternion.Euler(0f, 0f, -playerY);
        InventoryUpdate();
        HPUpdate();
    }
    private void InventoryUpdate()
    {
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
    private void HPUpdate()
    {
        HPbar.transform.localScale = new Vector3(0.5f, ((float)body.CurrenHealth / (float)body.HPMax)/2, 0.5f);
            Vector3 currentScale = HPbarEffect.transform.localScale;
            float targetY = HPbar.transform.localScale.y;

            // плавно меняем только Y
            currentScale.y = Mathf.Lerp(currentScale.y, targetY, Time.deltaTime * HPUpdateSpeed);

        HPbarEffect.transform.localScale = currentScale;
    }
}
