using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeekCounter : MonoBehaviour
{
    GameObject[] dateItems;
    ArrayList weekOne, weekTwo, weekThree, weekFour, leftOverDays;
    bool weeksCalculated = false;
    static readonly int MAXWEEKS = 4;
    int desiredWeek = 0;
    ArrayList selectedWeek = new ArrayList();


    void Awake()
    {
        weekOne = new ArrayList();
        weekTwo = new ArrayList();
        weekThree = new ArrayList();
        weekFour = new ArrayList();
        leftOverDays = new ArrayList();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CalculateWeeks()
    {
        UnHighlightWeek(desiredWeek);
        desiredWeek = 0;
        ClearWeeks();
        this.GetNumberOfDaysInMonth();
        for (int i = 0; i < dateItems.Length; i++)
        {
            if (i < 7)
            {
                weekOne.Add(dateItems[i]);
            }
            else if(i >= 7 && i < 14)
            {
                weekTwo.Add(dateItems[i]);
            }
            else if (i >= 14 && i < 21)
            {
                weekThree.Add(dateItems[i]);
            }
            else if(i >= 21 && i < 28)
            {
                weekFour.Add(dateItems[i]);
            }
            else
            {
                leftOverDays.Add(dateItems[i]);
            }
        }
    }

    void GetNumberOfDaysInMonth()
    {
        dateItems = GameObject.FindGameObjectsWithTag("DateItem");
    }

    void ClearWeeks()
    {
        weekOne.Clear();
        weekTwo.Clear();
        weekThree.Clear();
        weekFour.Clear();
        leftOverDays.Clear();
    }

    void HighlightWeek(int value)
    {
        switch(value)
        {
            case 4:
                selectedWeek = weekFour;
                break;
            case 3:
                selectedWeek = weekThree;
                break;
            case 2:
                selectedWeek = weekTwo;
                break;
            default:
                selectedWeek = weekOne;
                break;
        }
        foreach(GameObject day in selectedWeek)
        {
            day.GetComponent<DateItemActivation>().Activate();
        }
    }

    void UnHighlightWeek(int value)
    {
        switch (value)
        {
            case 4:
                selectedWeek = weekFour;
                break;
            case 3:
                selectedWeek = weekThree;
                break;
            case 2:
                selectedWeek = weekTwo;
                break;
            default:
                selectedWeek = weekOne;
                break;
        }
        foreach (GameObject day in selectedWeek)
        {
            day.GetComponent<DateItemActivation>().DeActivate();
        }
    }

    public void NextWeek()
    {
        UnHighlightWeek(desiredWeek);
        if (desiredWeek< MAXWEEKS)
        {
            desiredWeek++;
        }
        else
        {
            desiredWeek=0;
        }
        HighlightWeek(desiredWeek);
    }

    public void PreviousWeek()
    {
        UnHighlightWeek(desiredWeek);
        if (desiredWeek > 0)
        {
            desiredWeek--;
        }
        else
        {
            desiredWeek = 4;
        }
        HighlightWeek(desiredWeek);
    }

    public void ActivateEventIndicator()
    {
        foreach (GameObject day in selectedWeek)
        {
            day.GetComponent<DateItemActivation>().ActivateEventIndicator();
        }
    }

    public ArrayList GetSelectedWeek()
    {
        ArrayList arrayListOfDays = new ArrayList();
        foreach(GameObject day in selectedWeek)
        {
            arrayListOfDays.Add(day.GetComponent<CalendarDateItem>().GetValue());
        }
        return arrayListOfDays;
    }

    public void ResetWeekGUI()
    {
        this.GetNumberOfDaysInMonth();
        for (int i = 0; i < dateItems.Length; i++)
        {
            dateItems[i].GetComponent<DateItemActivation>().Reset();
        }
        EventRoster._eventRosterInstance.RemoveAllEvents();
    }
}
