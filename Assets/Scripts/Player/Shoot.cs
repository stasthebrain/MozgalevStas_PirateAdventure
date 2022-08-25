using UnityEngine;

namespace PirateQuest
{
    
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private float damage = 1f;
        [SerializeField] private float range = 30f;
        [SerializeField] private Camera cam;
        public ParticleSystem flash;
        public AudioSource shot;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                flash.Play();
                shot.Play();
                Fire();
            }
        }
        private void Fire()
        {
            
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {

                EnemySceleton target = hit.transform.GetComponent<EnemySceleton>();
                if (target != null)
                {
                    target.Hurt(damage);
                }
                EnemyBoss bosstarget = hit.transform.GetComponent<EnemyBoss>();
                if (bosstarget != null)
                {
                    bosstarget.Hurt(damage);
                }
            }
        }
    }
}