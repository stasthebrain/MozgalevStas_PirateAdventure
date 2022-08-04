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
        [SerializeField] GameObject Gate;

        void Start()
        {
            questText.text = "Осмотреться";
        }


        void Update()
        {
            if (KeyItem == 1f)
            {
                questText.text = "Найти то, что открывается ключом";
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" & Input.GetKeyDown(KeyCode.F) & KeyItem == 1f)
            {
                Destroy(Gate);
            }
            if (other.tag == "QuestItem" & Input.GetKeyDown(KeyCode.F))
            {
                KeyItem = KeyItem + 1f;
            }
        }
        
    }
}
