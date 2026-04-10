using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private Transform swordPrefab;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = swordPrefab.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
