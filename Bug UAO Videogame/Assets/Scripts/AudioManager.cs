using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    [SerializeField]AudioSource musicSource;
    [SerializeField]AudioSource sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        //sfxSource.clip = clip;
        sfxSource.PlayOneShot(clip);
    }
}
