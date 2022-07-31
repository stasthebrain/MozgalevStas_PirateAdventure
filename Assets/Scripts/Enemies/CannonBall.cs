using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateQuest
{
    public class CannonBall : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage = 0.2f;



        private void Update()
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Hit(collision.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Hit(other.gameObject);
        }

        private void Hit(GameObject collisionGO)
        {
            if (collisionGO.TryGetComponent(out HealthManager health))
            {
                health.Hit(damage);
            }
            Destroy(gameObject);
        }
    }
}
