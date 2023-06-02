using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{    
    [SerializeField]GameObject player;
    public Transform lastCheckPoint;
    [SerializeField] Vector3 vectorPoint;
    public Animator animator;
    public GameObject deathVFX;

    [SerializeField]  float dead;
    // Update is called once per frame
    void Update()
    {
        //CheckHeightDead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastCheckPoint = other.transform;
            vectorPoint = other.transform.position;
            Debug.Log("Entro El checkpoint");
        }
    }

    public void CheckHeightDead()
    {
        if (player.transform.position.y < -dead)
        {
            RespawnOnCheckPoint(); 
        }
    }

    public void RespawnOnCheckPoint()
    {
        //player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = vectorPoint;
        //player.GetComponent<CharacterController>().enabled = true;
        animator.SetBool("Death", false);
        deathVFX.GetComponent<ParticleSystem>().Stop();
        GetComponent<PlayerMovement>().enabled = true;
    }
}
