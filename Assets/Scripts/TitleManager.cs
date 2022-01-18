using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject blinkText;
    public float mfDelayTime = 0.2f;
    public float mfCurrentDelayTime = 1.0f;

    bool mbShowText = true;

    void Start()
    {
        //Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
        mfCurrentDelayTime = mfDelayTime;
    }

    void Update()
    {
        // 글씨 깜빡이기
        if (blinkText != null)
        {
            if (mfCurrentDelayTime > 0.0f)
            {
                mfCurrentDelayTime -= Time.deltaTime;
            }
            else
            {
                mfCurrentDelayTime = mfDelayTime;
                mbShowText = !mbShowText;
            }

            blinkText.SetActive(mbShowText);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
