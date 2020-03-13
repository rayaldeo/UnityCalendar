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

    public void CreateEvent(string eventName, string year, string month,ArrayList days)
    {
        Event _event = new Event(eventName, year, month, days);

        if (EventRoster._eventRosterInstance.Contains(_event))
        {
            Debug.Log("This event is already scheduled for that week");
            EventRoster._eventRosterInstance.Remove(_event);
            EventRoster._eventRosterInstance.AddMyEvent(_event);
        }
        else if(EventRoster._eventRosterInstance.GetSize() < CalendarSceneController._sceneController.MAXWEEKSTOFIGHT)
        {
            EventRoster._eventRosterInstance.AddMyEvent(_event);
            GetCalendarController().GetWeekCounter().ActivateEventIndicator();
        }
        else 
        {
            Debug.Log("Can't add any more weeks because you have used up all your weeks");
        }

         
    }

    public CalendarController GetCalendarController()
    {
        cc = GameObject.Find("CalendarController").GetComponent<CalendarController>();
        return cc;
    }

    
}
