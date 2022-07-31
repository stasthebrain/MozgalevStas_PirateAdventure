using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class QuestManager : MonoBehaviour
    {
        [SerializeField] private Text questText;


        void Start()
        {
            questText.text = "Осмотреться";
        }


        void Update()
        {
        }

    }
}
