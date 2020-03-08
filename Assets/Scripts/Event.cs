using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    string eventName;
    string day, year, month;

    public Event() { }

    public Event(string eventName, string year, string month,string day)
    {
        this.eventName = eventName;
        this.year = year;
        this.month = month;
        this.day = day;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetEventName()
    {
        return this.eventName;
    }

    public override string ToString()
    {
        return this.eventName + " created on " + this.GetYear() + " " + this.GetMonth() + " " + this.GetDay();
    }

    public void SetEventName(string value)
    {
        this.eventName = eventName;
    }

    public string GetYear()
    {
        return this.year;
    }

    public string GetMonth()
    {
        return this.month;
    }

    public string GetDay()
    {
        return this.day;
    }


}
