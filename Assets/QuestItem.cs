using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class QuestItem : MonoBehaviour
    {
        [SerializeField] GameObject KeyItemModel;
        private float KeyItem;
        [SerializeField] GameObject Gate;

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" & Input.GetKeyDown(KeyCode.F))
            {
                KeyItem = KeyItem + 1f;
                Destroy(KeyItemModel);
            }
            if (other.tag == "QuestItem" & Input.GetKeyDown(KeyCode.F) & KeyItem == 1f )
            {
                KeyItem = KeyItem - 1f;
                Destroy(Gate);
            }
        }
    }
}

