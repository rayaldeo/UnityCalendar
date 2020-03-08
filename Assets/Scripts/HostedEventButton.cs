using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostedEventButton : MonoBehaviour
{
    public string hostedEventName;
    public Text hostedEventField;

    EventModule eM = new EventModule();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hostedEventField.text = hostedEventName;
    }

    public void CreateEvent()
    {
        Debug.Log("This is the event name added:" + hostedEventName);
        eM = GameObject.Find("ChooseEventModule").GetComponent<EventModule>();
        eM.CreateEvent(this.hostedEventName, eM.GetCalendarController().GetYear(), eM.GetCalendarController().GetMonth(), eM.GetCalendarController().GetSelectedDay());
        eM.Disable();
    }
}
