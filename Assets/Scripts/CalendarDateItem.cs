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
        //CalendarController._calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
    }

    private void AddEvent()
    {
        eventModule.GetComponent<EventModule>().Enable();
    }

    public void Update()
    {
    }

    
}
