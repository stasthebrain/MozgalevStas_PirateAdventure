using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class QuestItem : MonoBehaviour
    {
        [SerializeField] GameObject KeyItemModel;
        [SerializeField] private Text itemText;


        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" & Input.GetKeyDown(KeyCode.F))
            {
                Destroy(KeyItemModel);
                itemText.text = " ";
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            
            itemText.text = "Нажмите F для поднятия предмета";

        }
        private void OnTriggerExit(Collider other)
        {
            itemText.text = " ";
        }
    }
}

