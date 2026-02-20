using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    BodyData body;
    Sword sword;
    Inventory inventory;
    public int StatsUpdateSpeed;
    [SerializeField] public Image Compass;
    [SerializeField] public Image HPbar;
    [SerializeField] public Image HPbarEffect;
    [SerializeField] public Image ManaBar;
    [SerializeField] public Image ManaBarEffect;
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
        ManaUpdate();
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
        HPbar.transform.localScale = new Vector3(2.5f, (((float)body.CurrentHealth  / (float)body.HPMax ) / 2) , 2.5f);
            Vector3 currentScale = HPbarEffect.transform.localScale;
            float targetY = HPbar.transform.localScale.y;

            // плавно меняем только Y
            currentScale.y = Mathf.Lerp(currentScale.y, targetY, Time.deltaTime * StatsUpdateSpeed);

        HPbarEffect.transform.localScale = currentScale;
    }
        private void ManaUpdate()
    {
        ManaBar.transform.localScale = new Vector3(2.5f, (((float)body.CurrentMana  / (float)body.ManaMax ) / 1.8f) , 2.5f);
            Vector3 currentManaScale = ManaBarEffect.transform.localScale;
            float targetY = ManaBar.transform.localScale.y;

            // плавно меняем только Y
            currentManaScale.y = Mathf.Lerp(currentManaScale.y, targetY, Time.deltaTime * StatsUpdateSpeed);

        ManaBarEffect.transform.localScale = currentManaScale;
    }
}
