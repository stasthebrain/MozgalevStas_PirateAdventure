using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //int a = 50;
    [SerializeField] private Transform cameraposition;
    void Update()
    {
        transform.position = cameraposition.position;
        //while(a>0)
        //{

        //    Debug.Log("dfkhgkjdfg");    
        //    a= a -1;
        //}
    }
}
