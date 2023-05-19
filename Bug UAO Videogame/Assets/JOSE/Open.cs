using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{

    bool doorOpen = false;
    public int objective = 3;

    public Animation doorany;

    private ScoringSystem scoreSystem;


    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoringSystem>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
            {
            if (!doorOpen)
            {
                if(scoreSystem.score >= objective)
                {
                    doorany.Play();
                    doorOpen = true;
                }

            }
            // abrir puerta
        }
    }
}
