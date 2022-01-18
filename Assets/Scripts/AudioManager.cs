using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip button; // 버튼 효과음
    public AudioClip check; // 체크 
    public AudioClip die; // 체크 효과음
    public DataManager dataManager;
    public float volum;

    AudioSource AS;

    const float VOLUM_VALUE = 0.516f;

    void Awake()
    {
        AS = this.GetComponent<AudioSource>();
        volum = VOLUM_VALUE;
    }

    public void soundButton()
    {
        if (dataManager.GetSoundEffect())
        {
            AS.clip = button;
            AS.Play();
        }
    }

    public void soundCheck()
    {
        if (dataManager.GetSoundEffect())
        {
            AS.clip = check;
            AS.Play();
        }
    }

    public void soundDie()
    {
        if (dataManager.GetSoundEffect())
        {
            AS.clip = die;
            AS.Play();
        }
    }
}
