using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete : MonoBehaviour
{
    private ScoringSystem scoreSystem;
    public int objective = 10;

    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoringSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && scoreSystem.score == objective)
        {
            {

                SceneManager.LoadScene(0);
            }
        }
    }
}
