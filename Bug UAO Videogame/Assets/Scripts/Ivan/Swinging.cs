using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour
{
[Header("Input")]
public KeyCode swingKey = KeyCode.Mouse0;

[Header("References")]
public LineRenderer lr;
public Transform gunTip, cam, player;
public LayerMask whatIsGrappleable;
public PlayerMovement pm;

[Header("Swinging")]
public float maxSwingDistance = 25f;
private Vector3 swingPoint;
private SpringJoint joint;

[Header("OdmGear")]
public Transform orientation;
public Rigidbody rb;
public float horizontalThrustForce;
public float forwardThrustForce;
public float extendCableSpeed;
public float shortenCableSpeed;


[Header("Prediction")]
public RaycastHit predictionHit;
public float predictionSphereCastRadius;
public Transform predictionPoint;


 private Animator animator;
    public GameObject objectToFind;
    string tagName = "SomeTag";


    
    private void Start()
   {
     
        objectToFind = GameObject.FindGameObjectWithTag(tagName);
        animator = objectToFind.GetComponent<Animator>();
    }




void Update()
{
    if (Input.GetKeyDown(swingKey)) StartSwing();
    if (Input.GetKeyUp(swingKey)) StopSwing();

    CheckForSwingPoints();

    if (joint != null) OdmGearMovement();
}

void LateUpdate()
{
    DrawRope();
}



     void StartSwing()
    {
        // return if predictionHit not found 
        if (predictionHit.point == Vector3.zero) return;

        //deactive active grapple
        if(GetComponent<Grappling>() != null)
        GetComponent<Grappling>().StopGrapple();
        pm.ResetRestrictions();
        animator.SetBool("start_swing", true);
         animator.SetBool("swinging", true);


        pm.swinging = true;

        
            swingPoint = predictionHit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = swingPoint;

            float distanceFromPoint = Vector3.Distance(player.position, swingPoint);

            // la distancia del grapple que va a mantener del grapple point
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Personaliza valores al gusot
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrappleposition = gunTip.position;
        

    }

    public void StopSwing()
    {
        pm.swinging = false;

        lr.positionCount = 0;
        Destroy(joint);
         animator.SetBool("start_swing", false);
          animator.SetBool("swinging", false);

    }
    private Vector3 currentGrappleposition;

    void DrawRope()
    {
        // if not grappling, dont draw rope
        if (!joint) return;

        currentGrappleposition = Vector3.Lerp(currentGrappleposition, swingPoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrappleposition);

    }

    private void OdmGearMovement()
    {
        // right
        if (Input.GetKey(KeyCode.D)) rb.AddForce(orientation.right * horizontalThrustForce * Time.deltaTime);
        // left
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-orientation.right * horizontalThrustForce * Time.deltaTime);
        
        // forward
        if (Input.GetKey(KeyCode.W)) rb.AddForce(orientation.forward * forwardThrustForce * Time.deltaTime);

         // forward
        if (Input.GetKey(KeyCode.S)) rb.AddForce(-orientation.forward * forwardThrustForce * Time.deltaTime);

        // shorten cable 
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 directionToPoint = swingPoint - transform.position;
            rb.AddForce(directionToPoint.normalized * forwardThrustForce * Time.deltaTime);

            float distanceFromPoint = Vector3.Distance(transform.position, swingPoint) - shortenCableSpeed;

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;
        }
        // extend cable 
        if (Input.GetKey(KeyCode.LeftControl))
        {
            float extendedDistanceFromPoint = Vector3.Distance(transform.position, swingPoint) + extendCableSpeed;

            joint.maxDistance = extendedDistanceFromPoint * 0.8f;
            joint.minDistance = extendedDistanceFromPoint * 0.25f;
        }
    }
    private void CheckForSwingPoints()
    {
        if (joint != null) return;

        RaycastHit sphereCastHit;
        Physics.SphereCast(cam.position, predictionSphereCastRadius, cam.forward, out sphereCastHit, maxSwingDistance, whatIsGrappleable);

        RaycastHit raycastHit;
        Physics.Raycast(cam.position, cam.forward, out raycastHit, maxSwingDistance, whatIsGrappleable);


        Vector3 realHitPoint;

        // option1 - Direct hit
        if (raycastHit.point != Vector3.zero)
            realHitPoint = raycastHit.point;

      // option2 - indirect predicted hit
        else if (sphereCastHit.point != Vector3.zero)
        realHitPoint = sphereCastHit.point;

        // option 3 - miss
        else
             realHitPoint = Vector3.zero; 

        // realhitpoint found
        if (realHitPoint != Vector3.zero)
        {
            predictionPoint.gameObject.SetActive(true);
            predictionPoint.position = realHitPoint;
        }   

        // realhitpoint not found
        else{
            predictionPoint.gameObject.SetActive(false);
        }
        predictionHit = raycastHit.point == Vector3.zero ? sphereCastHit : raycastHit;

    }

}
