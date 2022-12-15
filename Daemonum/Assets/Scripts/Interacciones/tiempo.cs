using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tiempo : MonoBehaviour
{
    public float timeRemaining = 300;
    public float timeBucle = 0.35f;
    [SerializeField] private bool timerIsRunning = false;
    [SerializeField] private Text timeStr;
    private void Start()
    {
        DisplayRandomTime();
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeStr.text = "Perdiste";
                GameObject.Find("Player").GetComponent<StatsPlayer>().omaeWaMouShindeiru();
                timeRemaining = 0;
            }
        }else{
            if (timeBucle > 0)
            {
                timeBucle -= Time.deltaTime;
            }
            else
            {
                timeBucle = 0.35f;
                DisplayRandomTime();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    timeStr.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void DisplayRandomTime()
    {
        int timeToDisplay =  Random.Range(1,3601);
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    timeStr.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
