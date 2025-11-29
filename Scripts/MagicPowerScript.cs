using System.Collections;
using UnityEngine;

public class MagicPowerScript : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform BallSpawnPos;

    [SerializeField] private GameObject MagicArmFov;      // обычная рука
    [SerializeField] private GameObject MagicArmAttack;   // рука которая атакует

    private float AttackCooldown = 0.3f;
    private bool CanAttack = true;

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

    private IEnumerator AttackOrb(GameObject SpawnBallPrefab)
    {
        CanAttack = false;

        // создаем шар
        Instantiate(SpawnBallPrefab, BallSpawnPos.position, BallSpawnPos.rotation);

        // включаем руку атаки
        MagicArmFov.SetActive(false);
        MagicArmAttack.SetActive(true);

        // ждем кулдаун
        yield return new WaitForSeconds(AttackCooldown);

        // возвращаем обычную руку
        MagicArmAttack.SetActive(false);
        MagicArmFov.SetActive(true);

        CanAttack = true;
    }
}