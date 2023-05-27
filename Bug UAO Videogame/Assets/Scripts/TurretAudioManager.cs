using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAudioManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip TurretInitSFX;
    public AudioClip TurretShootSFX;
    public AudioClip TurretCloseSFX;



    public void PlayInitialization(float volume)
    {
        source.clip = TurretInitSFX;
        source.volume = volume;
        source.Play();
        //source.PlayOneShot(TurretInitSFX, volume);
    }

    public void PlayShoot(float volume)
    {
        source.clip = TurretShootSFX;
        source.volume = volume;
        source.Play();
        //source.PlayOneShot(TurretShootSFX, volume);
    }

    public void PlayCose(float volume)
    {
        source.clip = TurretCloseSFX;
        source.volume = volume;
        source.Play();
        //source.PlayOneShot(TurretCloseSFX, volume);
    }

}
