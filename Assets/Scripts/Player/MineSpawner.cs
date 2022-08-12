using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mine; 
    [SerializeField] private Transform mineSpawnPlace; 
    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(mine, mineSpawnPlace.position, mineSpawnPlace.rotation);
        }
    }
}
