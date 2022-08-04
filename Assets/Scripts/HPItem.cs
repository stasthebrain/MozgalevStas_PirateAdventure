using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class HPItem : MonoBehaviour
    {
        [SerializeField] GameObject Model;
        [SerializeField] private Text itemText;
        [SerializeField] private float timer;



        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" & Input.GetKeyDown(KeyCode.F))
            {
                Destroy(Model);
                itemText.text = " ";
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            timer += Time.deltaTime;
            itemText.text = "Нажмите F для поднятия предмета";
           
        }
    }
}
