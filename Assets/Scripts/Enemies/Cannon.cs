using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject typeOfMissiles;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shootTime = 10f;
    [SerializeField] private float angularSpeed;
    private float nextShootTime;
    private Transform player;
    private float dist;
    [SerializeField] private float findDist;
    public AudioSource bomb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        DistanceFind();
        if (dist < findDist)
        {
            LookAtPlayer();
            Shoot();
        }
    }

    private void LookAtPlayer()
    {
        var direction = player.transform.position - transform.position;

        var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime, 0);

        transform.rotation = Quaternion.LookRotation(rotation);

    }
        


    void Shoot()
    {
        if (Time.time > nextShootTime)
        {
            bomb.Play();
            Instantiate(typeOfMissiles, spawnPoint.position, spawnPoint.rotation);
            nextShootTime = Time.time + shootTime;
            
        }
    }
    void DistanceFind()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
    }
}
