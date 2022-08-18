using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace PirateQuest
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private Text questText;
        private float KeyItem;
        [SerializeField] private Text questUseText;
        [SerializeField] private GameObject player;
        




        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Boat" && (Input.GetKeyDown(KeyCode.F) && KeyItem == 1f))
            {
                KeyItem = 0f;
                SceneManager.LoadScene(2);
            }
            if (other.tag == "QuestItem" & Input.GetKeyDown(KeyCode.F))
            {
                KeyItem = 1f;
                questText.text = "����� ���������� �����";
            }
            if (other.tag == "Boat" & (Input.GetKeyDown(KeyCode.F) && KeyItem == 0f))
            {
                questText.text = "��� ����� ������, ������� �����";
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Boat")
            {
                questUseText.text = "������� F, ����� ������";
            }
        }
        private void OnTriggerExit(Collider other)
        {
            questUseText.text = " ";
        }
        
    }
}
