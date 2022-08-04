
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
    [SerializeField] private Transform[] points;
    private int index;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(points[Random.Range(0, points.Length)].position);
    }


    private void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > findDist) 
        {
            Patroling();
        }
        else
        {
            
            agent.SetDestination(player.position);
        }
    }
    private void Patroling()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            index = (index + 1) % points.Length;
            agent.SetDestination(points[index].position);
        }
    }
}
