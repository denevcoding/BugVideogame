using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSystem : MonoBehaviour
{
    public GameObject petObject;
    public GameObject petObject2;
    public GameObject petObject3;
    public List<Vector3> positionList;
    public List<Vector3> positionList2;
    public List<Vector3> positionList3;
    public int distance = 40;
    public int distance2 = 60;
    public int distance3 = 80;
    // Update is called once per frame
    void Update()
    {
        if (ScoringSystem.score >= 1)
        {
            positionList.Add(transform.position);

            if (positionList.Count > distance)
            {
                positionList.RemoveAt(0);
                petObject.transform.position = positionList[0];
            }
        }

        if (ScoringSystem.score >= 2)
        {
            positionList2.Add(transform.position);

            if (positionList2.Count > distance2)
            {
                positionList2.RemoveAt(0);
                petObject2.transform.position = positionList2[0];
            }
        }

        if (ScoringSystem.score >= 3)
        {
            positionList3.Add(transform.position);

            if (positionList3.Count > distance3)
            {
                positionList3.RemoveAt(0);
                petObject3.transform.position = positionList3[0];
            }
        }

    }

}
