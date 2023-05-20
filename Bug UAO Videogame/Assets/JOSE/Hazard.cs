using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    PlayerHealth player;


    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            

            // Check if we actually found a player health script
            // This if statement is true if the player variable is NOT null (empty)
            if (player != null)
            {
                // This means there WAS a PlayerHealth script attached to the object we bumped into
                // Which means this object is indeed the player

                // Perform our on-collision action (kill the player)
                player.Kill();
            }
        }
    }

}