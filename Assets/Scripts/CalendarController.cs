using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
    //Set your desired date
    public int _desiredYear;
    public int _desiredMonth;
    public int _desiredDay;

    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;

    public GameObject _item;
    public GameObject _dateItemParent;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;
    public static CalendarController _calendarInstance;

    public string selectedDate;
    string selectedDay;


    void Start()
    {
        _calendarInstance = this;
        Vector3 startPos = _item.transform.localPosition;
        _dateItems.Clear();
        _dateItems.Add(_item);

        for (int i = 1; i < _totalDateNum; i++)
        {
            GameObject item = GameObject.Instantiate(_item) as GameObject;
            item.name = "Item" + (i + 1).ToString();
            item.transform.SetParent(_item.transform.parent);
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            item.transform.localPosition = new Vector3((i % 7) * 31 + startPos.x, startPos.y - (i / 7) * 25, startPos.z);

            _dateItems.Add(item);
        }

        SetStartingDate();
        
        CreateCalendar();

        _calendarPanel.SetActive(false);
    }

    void SetStartingDate()
    {
        if(this._desiredDay>0 && this._desiredDay < 32 
            && this._desiredMonth > 0 && this._desiredMonth < 13
            && this._desiredYear > 0 && this._desiredYear < 9999)
        {
            try
            {
                _dateTime = new DateTime(this._desiredYear, this._desiredMonth, this._desiredDay);
            }catch(ArgumentOutOfRangeException e)
            {
                Debug.Log("You entered in an invalid time; defaulting to present:" + e);
                _dateTime = DateTime.Now;
            }
        }
        else
        {
            _dateTime = DateTime.Now;
        }
    }

    void CreateCalendar()
    {
        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < _totalDateNum; i++)
        {
            Text label = _dateItems[i].GetComponentInChildren<Text>();
            _dateItems[i].SetActive(false);

            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    _dateItems[i].SetActive(true);

                    label.text = (date + 1).ToString();
                    date++;
                }
            }
        }
        _yearNumText.text = _dateTime.Year.ToString();
        _monthNumText.text = _dateTime.Month.ToString();
        GetWeekCounter().CalculateWeeks();
        GetWeekCounter().NextWeek();
    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
    }

    public void YearPrev()
    {
        _dateTime = _dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        _dateTime = _dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        GetWeekCounter().ResetWeekGUI();
        _dateTime = _dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        GetWeekCounter().ResetWeekGUI();
        _dateTime = _dateTime.AddMonths(1);
        CreateCalendar();
    }

    public void ShowCalendar(Text target)
    {
        _calendarPanel.SetActive(true);
        //_target = target;
        //_calendarPanel.transform.position = Input.mousePosition-new Vector3(0,120,0);
    }

    Text _target;
    public void OnDateItemClick(string day)
    {
        this.selectedDay = day;
        this.selectedDate = _yearNumText.text + " " + _monthNumText.text + " " + selectedDay + " ";
        _target.text = selectedDate;
        //_calendarPanel.SetActive(false);
    }

    public string GetSelectedDate()
    {
        return this.selectedDate;
    }

    public string GetYear()
    {
        return _dateTime.Year.ToString();
    }

    public string GetMonth()
    {
        return _dateTime.Month.ToString();
    }

    public string GetSelectedDay()
    {
        return this.selectedDay;
    }

    public WeekCounter GetWeekCounter()
    {
        return _dateItemParent.GetComponent<WeekCounter>();
    }

}
