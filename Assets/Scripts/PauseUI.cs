using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : DataManager
{
    public void Open()
    {
        base.BGMM();
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Mainmanu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
