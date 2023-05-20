using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Checkpoint checkpoint;

    private void Start()
    {
        checkpoint = FindObjectOfType<Checkpoint>();
    }

    public void Kill()
    {
        checkpoint.RespawnOnCheckPoint();
    }
}