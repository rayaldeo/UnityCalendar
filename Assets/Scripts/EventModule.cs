using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventModule : MonoBehaviour
{

    public Text selectedDate;
    public string dateValue;
    public string dayValue;
    CalendarController cc = new CalendarController();


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        selectedDate.text = cc.GetSelectedDate();
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
        Debug.Log("This event got created:"+_event.ToString());
        EventRoster._eventRosterInstance.AddMyEvent(_event);
    }

    public CalendarController GetCalendarController()
    {
        cc = GameObject.Find("CalendarController").GetComponent<CalendarController>();
        return cc;
    }

    
}
