using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PirateQuest
{
    public class HPItem : MonoBehaviour
    {
        [SerializeField] GameObject Model;
        

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player" & Input.GetKeyDown(KeyCode.F))
            {
                Destroy(Model);
            }
           
        }
        

    }


}
