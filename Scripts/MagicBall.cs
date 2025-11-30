using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    private Rigidbody BallRB;
    public float BallSpeed;
    [SerializeField] private float SpreadCoof;
    [SerializeField] GameObject FireParticle, FireSprite;

    void Start()
    {
        Vector3 OrbSpread = new Vector3(Random.Range(-SpreadCoof,SpreadCoof),Random.Range(-SpreadCoof/2,SpreadCoof/2),0);
        BallRB = GetComponent<Rigidbody>();
        FireParticle.transform.rotation = Quaternion.LookRotation(-(OrbSpread + transform.forward));
        BallRB.AddForce((transform.forward + OrbSpread) * BallSpeed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void LateUpdate()
    {
        FireSprite.transform.LookAt(Camera.main.transform);
    }
}