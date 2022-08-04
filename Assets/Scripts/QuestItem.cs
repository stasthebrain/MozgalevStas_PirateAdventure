using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class QuestItem : MonoBehaviour
    {
        [SerializeField] GameObject KeyItemModel;
        

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" & Input.GetKeyDown(KeyCode.F))
            {
                
                Destroy(KeyItemModel);
            }
        }
    }
}

