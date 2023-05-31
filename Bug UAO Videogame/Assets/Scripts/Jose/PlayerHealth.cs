using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Checkpoint checkpoint;
    public Animator animator;

    private void Start()
    {
        checkpoint = FindObjectOfType<Checkpoint>();
    }

    public void Kill()
    {
        GetComponent<PlayerMovement>().enabled = false;

        //Send Animator to death


      
        //checkpoint.RespawnOnCheckPoint();
    }


    public void Death()
    {
        DissolveController dissolver = GetComponent<DissolveController>();
        dissolver.Dissolve();
    }
}