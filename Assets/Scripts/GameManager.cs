using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverSet;
    public GameObject pauseButton;
    public Timer timer;
    public float bestScore;
    public bool gameOver;

    private string KeyString = "BestScore";
    private string bestScoreText = "최고기록: ";

    void Awake()
    {
        // ResetBestScore(); //DeBug To Reset
        bestScore = PlayerPrefs.GetFloat(KeyString, 0);
    }

    void Start()
    {
        //Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
        gameOver = false;
    }

    public void GameOver()
    {
        pauseButton.SetActive(false);
        gameOverSet.SetActive(true);
        gameOver = true;
        timer.timerOn = false;
        float score = timer.getTime();
        GameObject newImage = gameOverSet.transform.GetChild(3).gameObject;

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat(KeyString, bestScore);
            newImage.SetActive(true);
        }

        else
        {
            newImage.SetActive(false);
        }

        Transform bsText = gameOverSet.transform.Find("BestScore Text");
        bsText.GetComponent<Text>().text = bestScoreText + bestScore;


    }

    public void GameRetry()
    {
        SceneManager.LoadScene(1);
    }

    private void ResetBestScore()
    {
        PlayerPrefs.SetFloat(KeyString, 0);
    }
}
