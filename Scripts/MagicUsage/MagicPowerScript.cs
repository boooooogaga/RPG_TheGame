using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MagicPowerScript : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform BallSpawnPos;

    [SerializeField] private Sprite MagicArmIdle;      // ������� ����
    [SerializeField] private Sprite MagicArmAttack;   // ���� ������� �������
    [SerializeField] private Sprite MagicArmCD; //���� � ��


    [SerializeField] private Image MagicArmFov;
    [SerializeField] private GameObject FireBallSprite;

    BodyData body;


    private float AttackCooldown = 0.3f, OrbCooldown = 5f;
    private bool CanAttack = true;


    private void Start()
    {
        body = GetComponent<BodyData>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Attack(fireBall);
        }
    }

    private void Attack(GameObject Orb)
    {
        if (!CanAttack || body.CurrentMana <= 0) return;
        StartCoroutine(AttackOrb(Orb));
    }

    private IEnumerator AttackOrb(GameObject SpawnBallPrefab)
    {
        CanAttack = false;

        // ������� ���
        Instantiate(SpawnBallPrefab, BallSpawnPos.position, BallSpawnPos.rotation);

        body.CurrentMana -= 50;

        // �������� ���� �����
        MagicArmFov.sprite = MagicArmAttack;
        FireBallSprite.SetActive(false);

        // ���� �������
        yield return new WaitForSeconds(AttackCooldown);

        // ���������� ���� � ��
        MagicArmFov.sprite = MagicArmCD;

        yield return new WaitForSeconds(OrbCooldown);

        // ���������� ���� � Idle

        MagicArmFov.sprite = MagicArmIdle;
        FireBallSprite.SetActive(true);

        CanAttack = true;
    }
}