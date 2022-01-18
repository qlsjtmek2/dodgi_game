using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public GameObject joystick_leftCheck;
    public GameObject joystick_RightCheck;
    public AudioManager audioManager;
    public Toggle toggle;
    public Slider slider;

    BGMManager bgm;
    int isJoyStick_Left;
    int isSoundEffect;
    float volumBGM;

    private string name_JoyStick_Left = "JoyStick Left";
    private string name_SoundEffect = "Sound Effect";
    private string name_volumBGM = "BGM Volum";

    const int RESULT_TRUE = 1;
    const int RESULT_FALSE = 0;

    private int default_JoyStick_Left = RESULT_TRUE;
    private int default_SoundEffect = RESULT_TRUE;
    private float default_volumBGM = 100;


    void Awake()
    {
        if (!PlayerPrefs.HasKey(name_JoyStick_Left))
            PlayerPrefs.SetInt(name_JoyStick_Left, default_JoyStick_Left);
        if (!PlayerPrefs.HasKey(name_SoundEffect))
            PlayerPrefs.SetInt(name_SoundEffect, default_SoundEffect);
        if (!PlayerPrefs.HasKey(name_volumBGM))
            PlayerPrefs.SetFloat(name_volumBGM, default_volumBGM);

        isJoyStick_Left = PlayerPrefs.GetInt(name_JoyStick_Left);
        isSoundEffect = PlayerPrefs.GetInt(name_SoundEffect);
        volumBGM = PlayerPrefs.GetFloat(name_volumBGM);
    }

    void Start()
    {
        if (joystick_leftCheck != null)
            CheckJoyStick();
        if (toggle != null)
            CheckToggle();
        if (slider != null)
            CheckSlider();

        BGMM();
        if (bgm != null)
            bgm.SetVolume(GetBGMVolum());
    }

    public void SetJoyStickLeft(bool isLeft)
    {
        if (isLeft)
        {
            PlayerPrefs.SetInt(name_JoyStick_Left, RESULT_TRUE);
            isJoyStick_Left = RESULT_TRUE;
        }
        else
        {
            PlayerPrefs.SetInt(name_JoyStick_Left, RESULT_FALSE);
            isJoyStick_Left = RESULT_FALSE;
        }
    }

    public void SetSoundEffect(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt(name_SoundEffect, RESULT_TRUE);
            isSoundEffect = RESULT_TRUE;
        }
        else
        {
            PlayerPrefs.SetInt(name_SoundEffect, RESULT_FALSE);
            isSoundEffect = RESULT_FALSE;
        }
    }

    public void SetBGMVolum(float volum)
    {
        PlayerPrefs.SetFloat(name_volumBGM, volum);
        volumBGM = volum;
    }

    public bool GetJoyStickLeft()
    {
        if (isJoyStick_Left == 1)
            return true;
        else
            return false;
    }
    public bool GetSoundEffect()
    {
        if (isSoundEffect == 1)
            return true;
        else
            return false;
    }
    public float GetBGMVolum()
    {
        return volumBGM;
    }

    public void ClickJoyStickLeft(bool isLeft)
    {
        // 왼쪽으로 설정
        if (isLeft && isJoyStick_Left == RESULT_FALSE)
        {
            SetJoyStickLeft(isLeft);
            audioManager.soundCheck();
            CheckJoyStick();
        }

        // 오른쪽으로 설정
        else if (!isLeft && isJoyStick_Left == RESULT_TRUE)
        {
            SetJoyStickLeft(isLeft);
            audioManager.soundCheck();
            CheckJoyStick();
        }
    }

    public void ClickToggle()
    {
        SetSoundEffect(toggle.isOn);
    }

    public void ClickSlider()
    {
        SetBGMVolum(slider.value);
        bgm.SetVolume(GetBGMVolum());
    }

    public void BGMM()
    {
        GameObject obbgm = GameObject.FindWithTag("BGM");
        if (obbgm != null)
            bgm = obbgm.GetComponent<BGMManager>();
    }

    void CheckJoyStick()
    {
        if (joystick_leftCheck != null && joystick_RightCheck != null)
        {
            // 왼쪽 설정이면
            if (isJoyStick_Left == RESULT_TRUE)
            {
                joystick_leftCheck.SetActive(true);
                joystick_RightCheck.SetActive(false);
            }
            else
            {
                joystick_leftCheck.SetActive(false);
                joystick_RightCheck.SetActive(true);
            }
        }
    }

    void CheckToggle()
    {
        toggle.isOn = GetSoundEffect();
    }

    void CheckSlider()
    {
        slider.value = GetBGMVolum();
    }
}
