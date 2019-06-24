using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSound : MonoBehaviour
{
    private static BgSound instance;
    public static BgSound Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    [SerializeField] AudioClip[] bgMusics;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Instance = null;
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }


    public void SwitchBgMusic()
    {
        if(audioSource.clip == bgMusics[0])
        {
            audioSource.clip = bgMusics[1];
            audioSource.Play();
        } else
        {
            audioSource.clip = bgMusics[0];
            audioSource.Play();
        }
    }
}
