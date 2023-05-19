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

[Header("Swinging")]
private float maxSwingDistance = 25f;
private Vector3 swingPoint;
private SpringJoint joint;


void Update()
{
    if (Input.GetKeyDown(swingKey)) StartSwing();
    if (Input.GetKeyUp(swingKey)) StopSwing();
}

void LateUpdate()
{
    DrawRope();
}



     void StartSwing()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxSwingDistance, whatIsGrappleable))
        {
            swingPoint = hit.point;
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

    }

    void StopSwing()
    {
        lr.positionCount = 0;
        Destroy(joint);

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

}
