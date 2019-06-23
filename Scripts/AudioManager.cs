using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public static AudioManager adm;
    public AudioSource introMainMusic;
    public AudioSource efxMusic;

    public float lowPitchRange = 0.95f; 
    public float highPitchRange = 1.05f;   

    void Awake()
    {
        if(AudioManager.adm == null)
        {
            AudioManager.adm = this;//널 이면 그 곳은 나다
        }
        else if (adm != this)
        {
            StopMusic();
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    public void StartMusic()
    {
        introMainMusic.Play();
    }

    public void StopMusic()
    {
        introMainMusic.Stop();
    }
    /*
    public void RestartMusic()
    {
        if(AudioManager.adm == null)
        {
            introMainMusic.Play();
        }
        else if (adm != this)
        {
            StopMusic();
        }

        DontDestroyOnLoad(transform.gameObject);
    }*/

    public void PlaySingle (AudioClip clip)
    {
        efxMusic.clip = clip;
        efxMusic.Play();
    }   

    public void RandomizeSfx (params AudioClip[] clips)
    {
        int randomIndex = UnityEngine.Random.Range(0, clips.Length);
        float randomPictch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);

        efxMusic.pitch = randomPictch;
        efxMusic.clip = clips[randomIndex];
        efxMusic.Play();
    }
}
