using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    public bool Goten = false;

    private ScoringSystem scoreSystem;
    public GameObject target;
    public Vector3 targetPosOffset;
    public int offsetToFollow = 2;
    // public AudioSource collectSound;


    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoringSystem>();
    }


    private void Update()
    {
        if (Goten)
        {
            Vector3 pos = target.transform.position;
            Vector3 charToTarget = transform.position - target.transform.position;
            charToTarget.Normalize();
            Debug.DrawRay(target.transform.position, charToTarget * 1f, Color.blue);
            this.transform.position = ((charToTarget * 1f) + target.transform.position) ;
        }
        
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (!Goten)
            {
                FollowSystem follow = other.GetComponentInParent<FollowSystem>();

                Goten = true;
                target = other.gameObject;
                Debug.Log("Trigger " + gameObject.name);
                //   collectSound.Play();
                scoreSystem.AddScore();
                //Destroy(gameObject);
            }
        }
       
        


    }

}
