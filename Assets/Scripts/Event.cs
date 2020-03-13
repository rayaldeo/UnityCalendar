using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    string eventName;
    string year, month;
    ArrayList days;

    public Event() { }

    public Event(string eventName, string year, string month,ArrayList days)
    {
        this.eventName = eventName;
        this.year = year;
        this.month = month;
        this.days = days;
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

    public ArrayList GetDays()
    {
        return this.days;
    }

    public bool Equals(Event _event)
    {
        if (_event.GetDaysFromArray() == this.GetDaysFromArray() &&
            _event.GetMonth() == this.GetMonth() &&
            _event.GetYear() == this.GetYear())
        {
            return true;
        }
        return false;
    }

    string GetDaysFromArray()
    {
        string days = "[";
        foreach (string day in this.GetDays())
        {
            days += day + " ";
        }
        return days += "]";
    }

    #region Object Overrides
    public override string ToString()
    {
       
        return this.eventName + " created on " + this.GetYear() + " " + this.GetMonth() + " " + GetDaysFromArray();
    }
    #endregion


}
