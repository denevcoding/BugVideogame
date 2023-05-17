using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{

   // public AudioSource collectSound;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliton " + gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger " + gameObject.name);
     //   collectSound.Play();
        ScoringSystem.score += 1;       
        Destroy(gameObject);


    }

}
