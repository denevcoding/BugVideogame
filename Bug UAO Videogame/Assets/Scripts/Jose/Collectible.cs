using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    [SerializeField]
    private ScoringSystem scoreSystem;
    // public AudioSource collectSound;


    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoringSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliton " + gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger " + gameObject.name);
        //   collectSound.Play();

        
        scoreSystem.AddScore();
        Destroy(gameObject);


    }

}
