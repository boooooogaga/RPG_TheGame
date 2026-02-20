using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TriggerProxy : MonoBehaviour 
{
    public string zoneName; // Назовите как угодно: "Head", "Body", "Sensor"
    public Sword mainScript;

    private void Start()
    {
        mainScript = GetComponentInParent<Sword>();
    }
    public void ProcessTrigger(string zoneName, Collider other) 
    {
        // 1. Проверяем, что это точно враг, а не мы сами
        if (other.CompareTag("Enemy") && other.transform.root != transform.root)
        {
            BodyData enemyData = other.GetComponent<BodyData>();
            
            if(enemyData != null) 
            {
                enemyData.TakeDamage(50);
                Debug.Log($"Нанесено 50 урона объекту: {other.name}");
                
                // Если HP упало до 0 — удаляем
                if(enemyData.CurrentHealth <= 0) 
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
        {
            ProcessTrigger( "-" , other);
        }
}
