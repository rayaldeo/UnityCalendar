using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventModule : MonoBehaviour
{

   CalendarController cc = new CalendarController();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable()
    {
        GetCalendarController();
        this.gameObject.SetActive(true);
    }

    public void CreateEvent(string eventName, string year, string month,string day)
    {
        Event _event = new Event(eventName, year, month, day);
        EventRoster._eventRosterInstance.AddMyEvent(_event);
    }

    public CalendarController GetCalendarController()
    {
        cc = GameObject.Find("CalendarController").GetComponent<CalendarController>();
        return cc;
    }

    
}
