using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    SwordData data;

    BoxCollider attackCollider;

    private void Awake()
    {
        attackCollider = GetComponent<BoxCollider>();

        attackCollider.enabled = false;
    }

    public IEnumerator Attack()
    {
        Debug.Log("Attack");
        yield return new WaitForSeconds(data.attackDelay);
        attackCollider.enabled = true;
        yield return new WaitForSeconds(data.attackTime);
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
