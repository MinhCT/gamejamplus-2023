using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds,sfxLoopSounds, sfxSounds;
    public AudioSource musicSource, sfxLoopSource,sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Music Sound not found: " + name);
        }
        else
        {
            musicSource.clip = sound.audioClip;
            musicSource.Play();
        }
    }
    
    public void PlaySFXLoop(string name)
    {
        Sound sound = Array.Find(sfxLoopSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Music Sound not found: " + name);
        }
        else
        {
            sfxLoopSource.clip = sound.audioClip;
            sfxLoopSource.Play();
        }
    }
    
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("SFX Sound not found: " + name);
        }
        else
        {
            sfxSource.PlayOneShot(sound.audioClip);
        }
    }
}
