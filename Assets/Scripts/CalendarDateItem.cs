using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour {

    public GameObject eventModule;
    Event _event;
    string dayValue;
   

    public void OnDateItemClick()
    {
        Debug.Log("Date button was clicked");
        AddEvent();
        Debug.Log("Text Value for day is:"+ gameObject.GetComponentInChildren<Text>().text);
        CalendarController._calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
    }

    private void AddEvent()
    {
        eventModule.GetComponent<EventModule>().Enable();
    }

    public void Update()
    {
    }

    
}
