using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    private Rigidbody BallRB;
    public float BallSpeed = 5000f;
    

    void Start()
    {
        BallRB = GetComponent<Rigidbody>();
        BallRB.AddForce(transform.forward * BallSpeed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}