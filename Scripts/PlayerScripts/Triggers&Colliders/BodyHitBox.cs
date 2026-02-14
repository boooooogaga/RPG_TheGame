using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHitBox : MonoBehaviour
{
    public BodyData body;
    private void OnTriggerEnter(Collider other)
    {
        body = GetComponentInParent<BodyData>();
        if (other.CompareTag("Enemy"))
        {
        body.TakeDamage(50);
        Debug.Log("Damage via Trigger");
        }   
    }
}
