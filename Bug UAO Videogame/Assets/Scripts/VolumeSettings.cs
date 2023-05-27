using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class VolumeSettings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicVolume;
    public Slider sfxVolume;

    const string MusicKey = "MusicVolume";
    const string sfxKey = "SFXVolume";

    private void Awake()
    {
        musicVolume.onValueChanged.AddListener(SetMusicVolume);
        sfxVolume.onValueChanged.AddListener(SetSFXVolume);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MusicKey, value);
    }
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(sfxKey, value);

    }
}
