using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSoundManager : MonoBehaviour
{
    AudioSource dooraudio;
    // Start is called before the first frame update
    void Start()
    {
        dooraudio = GetComponent <AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play_sound()
    {
        dooraudio.Play();
    }
}
