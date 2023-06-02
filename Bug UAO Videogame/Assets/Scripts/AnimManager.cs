using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Checkpoint checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  //  this function enters when death animation gets to the last frame
    public void Death()
    {
        playerHealth.Death();
    }

    public void CheckPoint()
    {
        checkpoint.RespawnOnCheckPoint();
    }
}
