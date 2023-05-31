using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Checkpoint checkpoint;
    public Animator animator;
    public GameObject deathVFX;

    private void Start()
    {
        checkpoint = FindObjectOfType<Checkpoint>();
    }

    public void Kill()
    {
        GetComponent<PlayerMovement>().enabled = false;

        //deathVFX.SetActive(true);
        deathVFX.GetComponent<ParticleSystem>().Play();
        //Send Animator to death
        animator.SetBool("Death", true);

        //checkpoint.RespawnOnCheckPoint();
    }


    public void Death()
    {
        //DissolveController dissolver = GetComponent<DissolveController>();
        //dissolver.Dissolve();
    }
}