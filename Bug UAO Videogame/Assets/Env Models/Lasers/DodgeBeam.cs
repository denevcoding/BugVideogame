using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBeam : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform startPoint;


    void start()
    {
        lr = GetComponent<LineRenderer>();
    }


    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.transform.tag == "Player")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else lr.SetPosition(1, -transform.right * 5000);
    }
}
