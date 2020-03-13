using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventRoster : MonoBehaviour
{
    public static List<Event> myEvents = new List<Event>();
    public GameObject eventDetailText;
    public static EventRoster _eventRosterInstance = new EventRoster();

    public void AddMyEvent(Event _event)
    { 
        myEvents.Add(_event);
        Debug.Log("This is the event name added:" + _event.ToString());
        Debug.Log("Event was added:" + GetSize());
        //ClearRoster();
        //ShowMyEvents();
    }
       
    public int GetSize()
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
        foreach(Event eventObject in myEvents)
        {
            if (eventObject.Equals(_event))
                return true;
        }
        return false;
    }

    public void Remove(Event _event)
    {
        Debug.Log("Removing Event");
        myEvents.Remove(_event);
    }

    public void RemoveAllEvents()
    {
        Debug.Log("Removing all Events");
        myEvents.Clear();
    }
}
