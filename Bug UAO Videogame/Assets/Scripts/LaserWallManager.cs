using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWallManager : MonoBehaviour
{
    public List<GameObject> lasers = new List<GameObject>();
    //public int laserAmount;
    public float heightValue;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.childCount);

        for (int i = 0; i < transform.childCount; i++)
        {
            LeanTween.moveLocalY(transform.GetChild(i).gameObject, heightValue, time).setEaseInOutCubic().setLoopPingPong();
            lasers.Add(transform.GetChild(i).gameObject);  
        }

        //LeanTween.moveLocalY(lasers[0].gameObject, 3f, time).setEaseInOutCubic().setLoopPingPong();
        //LeanTween.moveLocalY(lasers[1].gameObject, 1.5f, time).setEaseInOutCubic().setLoopPingPong();
        //LeanTween.moveLocalY(lasers[2].gameObject, 0f, time).setEaseInOutCubic().setLoopPingPong();

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
