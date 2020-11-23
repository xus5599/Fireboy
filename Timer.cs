﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static int tempo;
    private float StartTime;
    public Text tiempo;
    void Start()
    {
        StartTime = Time.time;
       GetComponent<Timer>();
       
    }
    void Update()
    {
        if (tempo == 0)
        {
            float TimerControl = Time.time - StartTime;
            string mins = ((int)TimerControl / 60).ToString("00");
            string segs = (TimerControl % 60).ToString("00");
            string milisegs = ((TimerControl * 100) % 100).ToString("00");

            string TimerString = string.Format("{00}:{01}:{02}", mins, segs, milisegs);

            GetComponent<Text>().text = TimerString.ToString();
            tiempo.text = TimerString.ToString();
        }
        
    }
     
    

}