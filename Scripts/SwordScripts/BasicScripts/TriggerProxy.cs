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
    private void OnTriggerEnter(Collider other) 
    {
        // Передаем информацию в главный скрипт
        mainScript.ProcessTrigger(zoneName, other);
    }
}
