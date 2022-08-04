using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Follow : MonoBehaviour
{
    private float dist;
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField] private float findDist;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    private void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > findDist)
        {
            agent.enabled = false;
        }
        else
        {
            agent.enabled = true;
            agent.SetDestination(player.position);
        }
    }
}
