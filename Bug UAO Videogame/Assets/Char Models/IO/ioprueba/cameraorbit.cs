using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraorbit : MonoBehaviour
    
{
    public Transform follow;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
         transform.position = follow.position + new Vector3(0,0,-distance);
    }
}
