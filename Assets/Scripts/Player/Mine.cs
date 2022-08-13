using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PirateQuest
{

    public class Mine : MonoBehaviour
    {
        [SerializeField] GameObject MineModel;
        [SerializeField] private int _damage;
        [SerializeField] private float Radius;
        [SerializeField] private float Force;
        //[SerializeField] private GameObject explodeEffect;

        public void Explode()
        {
            Collider[] overlapColliders = Physics.OverlapSphere(transform.position, Radius);
            for (int i = 0; i < overlapColliders.Length; i++)
            {
                Rigidbody rigidbody = overlapColliders[i].attachedRigidbody;
                if (rigidbody)
                {
                    rigidbody.AddExplosionForce(Force, transform.position, Radius); 
                }
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<EnemySceleton>();
                enemy.Hurt(_damage);
                Destroy(MineModel);
                Explode();
                //Instantiate(explodeEffect, transform.position, Quaternion.identity);
            }
        }

    }
}   