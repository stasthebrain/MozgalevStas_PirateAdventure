using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PirateQuest
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Patrol : MonoBehaviour
    {
        NavMeshAgent agent;
        [SerializeField] private Transform[] points;
        private int index;

        
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(points[0].position);
            
        }
        void Update()
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                
                index = (index + 1) % points.Length;
                agent.SetDestination(points[index].position);
            }
        }
    }
}
