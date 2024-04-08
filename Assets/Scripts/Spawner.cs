using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject pinPrefab;
    public float delay = 0.5f;
 
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("SpawnPin", delay, delay);
        }
    }

   
    void SpawnPin()
    {
        Pin pin = pinPrefab.GetComponent<Pin>();
        pin.speed = 50f;
        Instantiate(pin, transform.position, transform.rotation);
        CancelInvoke("SpawnPin");
    }

  
}
