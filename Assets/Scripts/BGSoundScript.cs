using UnityEngine;
using System.Collections;

public class BGSoundScript : MonoBehaviour 
{
    //public AudioSource musicSource;
    private static BGSoundScript instance = null;

    public static BGSoundScript Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad (gameObject);
    }

    //public void PlayMusic(AudioClip clip)
    //{
    //    musicSource.clip = clip;
    //    musicSource.Play ();
    //}

    //public void StopMusic(AudioClip clip)
    //{
    //    musicSource.clip = clip;
    //    musicSource.Stop ();
    //}

}
