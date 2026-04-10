using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Inventory inventory;
    public Sword sword;
    public NavMeshAgent agent;
    public BodyData body;
    public GameObject player;
    [SerializeField] private Transform swordPrefab;
    void Start()
    {
        inventory = GetComponent<Inventory>();
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<BodyData>();
        sword = GetComponent<Sword>();
        sword.currentSword = inventory.Swords[0];
        player = GameObject.Find("Player");
        agent.destination = swordPrefab.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(body.CurrentHealth > body.HPMax / 2)
        {
            RageAttack();
        }
        else
        {
            agent.speed = 1.5f;
            agent.destination = swordPrefab.transform.position;
        }
    }
    public void RageAttack()
    {
        agent.speed = 3.5f;
        agent.destination = player.transform.position;
        Vector3 directionToPlayer = player.transform.position - transform.position;
        if (directionToPlayer.magnitude < 2f)
        {
            sword.Attack();
            Debug.Log("Enemy attacked the player!");
        }
    }
}
