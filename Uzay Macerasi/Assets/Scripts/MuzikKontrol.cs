using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{

    public static MuzikKontrol instance;

    AudioSource audioSource;


    void Awake()
    {
        Singelton();
        audioSource = GetComponent<AudioSource>();   
    }

    void Singelton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void MuzikCal(bool play)
    {
        if (play)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
