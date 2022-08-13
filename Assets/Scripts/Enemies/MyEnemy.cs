using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateQuest
{
    public class MyEnemy : MonoBehaviour
    {
        [SerializeField] private float EnemyHealth;
        public void Hurt(float damage)
        {

            EnemyHealth -= damage; ;
            if (EnemyHealth <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}

