using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : MonoBehaviour
{
    public bool Goten = false;

    private ScoringSystem scoreSystem;
    public GameObject target;
    [SerializeField] private Transform targetpos;
    public Vector3 targetPosOffset;
    public int offsetToFollow = 2;
    private int x, y, z;
    public float distance;

    // public AudioSource collectSound;


    private void Start()
    {
        scoreSystem = FindObjectOfType<ScoringSystem>();

       
    }


    private void Update()
    {

        Collected();

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
                targetpos = other.transform;
                Debug.Log("Trigger " + gameObject.name);
                //   collectSound.Play();
                distance = 1f + scoreSystem.score;
                scoreSystem.AddScore();
                //Destroy(gameObject);
                
            }
        }
       
        
        

    }

    public void Collected()
    {

        if (Goten)
        {
            Vector3 pos = target.transform.position;
            Vector3 charToTarget = transform.position - target.transform.position;
            charToTarget.Normalize();
            Debug.DrawRay(target.transform.position, charToTarget * 1f, Color.blue);
            this.transform.position = ((charToTarget * distance) + target.transform.position);
            transform.LookAt(targetpos);
            transform.Rotate(x, y, z);
        }
    }

   
}
