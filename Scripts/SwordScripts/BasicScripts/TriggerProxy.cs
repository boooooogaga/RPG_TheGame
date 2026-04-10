using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TriggerProxy : MonoBehaviour 
{
 // Назовите как угодно: "Head", "Body", "Sensor"
    public Sword mainScript;

    private void Start()
    {
        mainScript = GetComponentInParent<Sword>();
    }
    public void ProcessTrigger(Collider other) 
    {
        // 1. Проверяем, что это точно враг, а не мы сами
            BodyData enemyData = other.GetComponent<BodyData>();
            
            if(enemyData != null && other.gameObject != mainScript.gameObject) 
            {
                enemyData.TakeDamage(mainScript.currentSword.damage);
                Debug.Log($"Нанесено {mainScript.currentSword.damage} урона объекту: {other.name}");
                
                // Если HP упало до 0 — удаляем
                if(enemyData.CurrentHealth <= 0) 
                {
                    Destroy(other.gameObject);
                }
            }
    }
    public void OnTriggerEnter(Collider other)
        {
            ProcessTrigger(other);
        }
}
