using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MagicPowerScript : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform FireBallSpawnPos;
    private Rigidbody BallRB;
    [SerializeField]private Transform PlayerPos;
    private float BallSpeed = 10f;

    private void Start()
    {
        
    }
    private void Update()
    {
        
        
            if (Input.GetMouseButtonDown(1))
            {
                Instantiate(fireBall, FireBallSpawnPos.position, PlayerPos.rotation);
                BallRB = fireBall.GetComponent<Rigidbody>();
            if (BallRB != null)
            {
                BallRB.AddForce(Vector3.forward * BallSpeed, ForceMode.Impulse);
            }
                
            }
        
    }
}
