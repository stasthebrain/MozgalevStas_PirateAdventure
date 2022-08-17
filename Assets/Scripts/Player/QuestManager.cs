using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private Text questText;
        private float KeyItem;
        [SerializeField] private Text questUseText;
        [SerializeField] private GameObject player;
        [SerializeField] private Transform NextLvlSpawn;

        //void Start()
        //{
        //    questText.text = "Осмотреться";
        //}



        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Boat" && (Input.GetKeyDown(KeyCode.F) && KeyItem == 1f))
            {
                player.transform.position = NextLvlSpawn.position;
            }
            if (other.tag == "QuestItem" & Input.GetKeyDown(KeyCode.F))
            {
                KeyItem = 1f;
                questText.text = "Найти применение веслу";
            }
            if (other.tag == "Boat" & (Input.GetKeyDown(KeyCode.F) && KeyItem == 0f))
            {
                questText.text = "Вам нечем грести, найдите весло";
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Boat")
            {
                questUseText.text = "Нажмите F, чтобы уплыть";
            }
        }
        private void OnTriggerExit(Collider other)
        {
            questUseText.text = " ";
        }
    }
}
