using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbod;
     
    public float speed = 10f

    void Start()
    {
        rigidbody = GetComponent<RigidBody>();

    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if ( hor != 0.0f || ver != 0.0f){
              Vector3 dir = transform.foward * ver + transform.rigth * hor;


            rigidbody.MovePosition(transform.position + dir * speed * Time.delta

        }

    }
}
