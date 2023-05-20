using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public int objective = 3;
    private ScoringSystem scoreSystem;
    public string Dooropenparam = "DoorOpen";
    public Animator animator;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoringSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            if (scoreSystem.score >= objective)
            {
                animator.SetBool(Dooropenparam, true);

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {

            if (scoreSystem.score >= objective)
            {
                animator.SetBool(Dooropenparam, false);

            }

        }
    }
}
