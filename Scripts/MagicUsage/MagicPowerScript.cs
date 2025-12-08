using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MagicPowerScript : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform BallSpawnPos;

    [SerializeField] private Sprite MagicArmIdle;      // обычная рука
    [SerializeField] private Sprite MagicArmAttack;   // рука которая атакует
    [SerializeField] private Sprite MagicArmCD; //Рука в кд


    [SerializeField] private Image MagicArmFov;
    [SerializeField] private GameObject FireBallSprite;


    private float AttackCooldown = 0.3f, OrbCooldown = 5f;
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
        MagicArmFov.sprite = MagicArmAttack;
        FireBallSprite.SetActive(false);

        // ждем кулдаун
        yield return new WaitForSeconds(AttackCooldown);

        // возвращаем руку в кд
        MagicArmFov.sprite = MagicArmCD;

        yield return new WaitForSeconds(OrbCooldown);

        // возвращаем руку в Idle

        MagicArmFov.sprite = MagicArmIdle;
        FireBallSprite.SetActive(true);

        CanAttack = true;
    }
}