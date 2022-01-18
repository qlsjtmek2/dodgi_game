using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    static BGMManager instance;
    public AudioClip[] Music = new AudioClip[2]; // 사용할 BGM
    public AudioClip titleMusic;

    protected AudioSource audioSource;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            RandomPlay();
        }
    }

    public void RandomPlay()
    {
        audioSource.clip = Music[Random.Range(0, Music.Length)];
        audioSource.Play();
    }
    public void TitlePlay()
    {
        audioSource.clip = titleMusic;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}