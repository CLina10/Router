﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float startTime;
    bool finnished = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (finnished)
        {
            return;
        }

        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.red;
    }
}