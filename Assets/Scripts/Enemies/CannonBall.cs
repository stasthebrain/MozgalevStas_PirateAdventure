using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateQuest
{
    [RequireComponent(typeof(Rigidbody))]
    public class CannonBall : MonoBehaviour
    {
        [SerializeField] private float speed = 30f;
        [SerializeField] private float damage = 0.2f;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
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
