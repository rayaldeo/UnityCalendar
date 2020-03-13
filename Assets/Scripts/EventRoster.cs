using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventRoster : MonoBehaviour
{
    public static List<Event> myEvents = new List<Event>();
    public GameObject eventDetailText;
    public static EventRoster _eventRosterInstance = new EventRoster();

    public void AddMyEvent(Event value)
    { 
        myEvents.Add(value);
        Debug.Log("Event was added:" + GetSize());
        //ClearRoster();
        //ShowMyEvents();
    }
       
    public static int GetSize()
    {
        return myEvents.Count;
    }

    public void ShowMyEvents()
    {
        //Instantiate(_eventFieldprefab);
        //Transform newText;
        foreach (Event _event in myEvents)
        {
            GameObject item = GameObject.Instantiate(eventDetailText,transform) as GameObject;
            item.transform.Find("Text").GetComponent<Text>().text = _event.ToString();
        }
    }

    public void Start()
    {
        _eventRosterInstance = this;
    }

    public void Update()
    {
    }

    public void ClearRoster()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public bool Contains(Event _event)
    {
        //foreach(Event eventObject in myEvents)
        return true;
    }
}
