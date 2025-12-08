using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class UseOfItems : MonoBehaviour
{
    public IUsable itemInHand;
    private Sword sword;
    [SerializeField] private Image ArmFov;
    private void Start()
    {
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
    }
   
}