using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBeam : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform startPoint;

    public Vector3 axis;
    public float rotAmount;
    public float time;
    public LeanTweenType easeType; 


    public float laserDistance;
    public LayerMask damageMask;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        LeanTween.rotateAround(gameObject, axis, rotAmount, time).setEase(easeType).setLoopPingPong();   
    }

    void Update()
    {
        CastRay();
        //lr.SetPosition(0, startPoint.position);
        //RaycastHit hit;

        //if (Physics.Raycast(transform.position, -transform.right, out hit))
        //{
        //    if (hit.collider)
        //    {
        //        lr.SetPosition(1, hit.point);
        //    }
        //    if (hit.transform.tag == "Player")
        //    {
        //        Destroy(hit.transform.gameObject);
        //    }
        //}
        //else lr.SetPosition(1, -transform.right * 5000);
    }


    public void CastRay()
    {
        Debug.DrawRay(transform.position, transform.forward * laserDistance, Color.red);

        bool hitted = false;

        RaycastHit hit;
        hitted = Physics.Raycast(transform.position, transform.forward, out hit, laserDistance, damageMask.value);

        if (hitted)
        {
            Debug.Log("Catched: " + hit.collider.gameObject.name);       
        }
    }


}
