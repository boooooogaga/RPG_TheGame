using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MagicPowerScript : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;

    [SerializeField] private Transform BallSpawnPos;

    public Sprite IdleArm;
    public Sprite AttackArm;

    private float AttackCouldown = 0.1f;

    private bool CanAttack = true;

    public Image ArmRenderer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Attack(fireBall);
        } 
    }
    private void Attack(GameObject Orb)
    {
        if (!CanAttack) return;
        StartCoroutine(AttackOrb(Orb));
    }
    private IEnumerator AttackOrb(GameObject SpanwBallPref)
    {
        CanAttack = false;
        Instantiate(SpanwBallPref, BallSpawnPos.position, BallSpawnPos.rotation);
        ArmRenderer.sprite = AttackArm;
        yield return new WaitForSeconds(AttackCouldown);
        ArmRenderer.sprite = IdleArm;
        CanAttack = true;
    }
}
