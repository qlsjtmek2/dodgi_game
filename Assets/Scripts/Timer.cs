using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public GameManager gameManager;
	public bool timerOn = true;
	public float totalTime = 0f;

	private int minute = 0;
	private int second = 0;
	private int tic = 0;

	void Update()
	{
		if (timerOn)
		{
			totalTime += Time.deltaTime;
		}
		this.GetComponent<Text>().text = string.Format("{0:0.#}", totalTime);
	}

	private string TimerCalc()
	{
		tic = (int)((totalTime % 1) * 100);

		second = (int)totalTime % 60;

		minute = (int)totalTime / 60;

		return minute + " : " + second + " : " + tic;
	}

	public float getTime()
    {
		return float.Parse(string.Format("{0:0.#}", totalTime));
	}
}
