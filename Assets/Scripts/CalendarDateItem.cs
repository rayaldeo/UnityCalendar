﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour {

    public GameObject eventModule;
    public Text dateValue;
    Event _event;
    string dayValue;
   

    public void OnDateItemClick()
    {
        AddEvent();
        //CalendarController._calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
    }

    private void AddEvent()
    {
        eventModule.GetComponent<EventModule>().Enable();
    }

    private void DisAbleBackgroundObjects()
    {

    }

    public void Update()
    {
    }

    public string GetValue()
    {
        return dateValue.text;
    }

    
}
