using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class HealthManager : MonoBehaviour
    {
        //[SerializeField] private Text GameOverText;
        //[SerializeField] private Camera camera;
        public float HP =1f;
        [SerializeField] private Image UIHP;
        public Text HPBottleT;
        public float HPBottle = 0f;

        private void Update()
        {
            UIHP.fillAmount = HP;
            HPBottleT.text = "" + HPBottle;
            if (Input.GetKeyDown(KeyCode.E) & HPBottle > 0f & HP < 1f)
            {
                HP = HP + 0.25f;
                HPBottle = HPBottle - 1f;
                if (HP > 1f)
                {
                    HP = 1f;
                }
            }
            //if (camera.transform.position.y <= 5.5f)
            //{
            //    Destroy(camera);
            //}

        }
        public void Hit(float damage)
        {
           
            HP -= damage;
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "HPItem" & Input.GetKeyDown(KeyCode.F))
            {
                HPBottle = HPBottle + 1f;
            }
        }
        //void GameOver()
        //{
        //    GameOverText.text = "Конец";
        //}

    }
}
