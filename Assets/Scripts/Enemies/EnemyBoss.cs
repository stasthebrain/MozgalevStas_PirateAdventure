
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PirateQuest
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyBoss : MonoBehaviour
    {
        private float dist;
        private NavMeshAgent agent;
        private Transform player1;
        [SerializeField] private float findDist;
        [SerializeField] private Transform[] points;
        [SerializeField] private float EnemyHealth = 1f;
        [SerializeField] private GameObject CapitanBadge;
        [SerializeField] private Transform badgeSpawnPlace;
        [SerializeField] private GameObject endGameMenu;
        public int key;

        private float timer;
        private float nextShootTime;
        private int index;
        Animator animator;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            player1 = GameObject.FindGameObjectWithTag("Player").transform;
            agent.SetDestination(points[Random.Range(0, points.Length)].position);
            animator = GetComponent<Animator>();

        }


        private void Update()
        {
            dist = Vector3.Distance(player1.transform.position, transform.position);

            if (dist > findDist)
            {

                Patroling();
            }
            else
            {

                agent.SetDestination(player1.position);

            }
            animStop();

            


        }
        private void Patroling()
        {

            if (agent.remainingDistance <= agent.stoppingDistance)
            {


                //timer += Time.deltaTime;
                //if (timer > 3)
                //{
                //    timer = 0;
                index = (index + 1) % points.Length;
                agent.SetDestination(points[index].position);
                //}

            }
        }
        public void Hurt(float damage)
        {

            EnemyHealth -= damage; ;
            if (EnemyHealth <= 0)
            {
                Die();

                EndGame();
            }
        }
        private void Die()
        {
            
            Destroy(gameObject);
            

        }
        void DistanceFind()
        {
            dist = Vector3.Distance(player1.transform.position, transform.position);
        }
        private void animStop()
        {
            animator.SetBool("isMoving", false);
            if (transform.hasChanged)
            {
                animator.SetBool("isMoving", true);
            }
        }
        public void EndGame()
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            endGameMenu.SetActive(true);

        }
    }
}

