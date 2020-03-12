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
            else if(i >= 7 && i <= 14)
            {
                weekTwo.Add(dateItems[i]);
            }
            else if (i >= 14 && i <= 21)
            {
                weekThree.Add(dateItems[i]);
            }
            else if(i >= 21 && i <= 28)
            {
                weekFour.Add(dateItems[i]);
            }
            else
            {
                leftOverDays.Add(dateItems[i]);
            }
        }
        Debug.Log("Week One Complete: " + weekOne.Count);
        Debug.Log("Week Two Complete: " + weekTwo.Count);
        Debug.Log("Week Three Complete: " + weekThree.Count);
        Debug.Log("Week Four Complete: " + weekFour.Count);
        Debug.Log("Left Over days: " + leftOverDays.Count);

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

    public void HighlightWeek(int value)
    {
        ArrayList desiredWeek= new ArrayList();
        switch(value)
        {
            case 4:
                desiredWeek = weekFour;
                break;
            case 3:
                desiredWeek = weekThree;
                break;
            case 2:
                desiredWeek = weekTwo;
                break;
            default:
                desiredWeek = weekOne;
                break;
        }
        foreach(GameObject day in desiredWeek)
        {
            day.GetComponent<DateItemActivation>().Activate();
        }
    }

    public void UnHighlightWeek(int value)
    {
        ArrayList desiredWeek = new ArrayList();
        switch (value)
        {
            case 4:
                desiredWeek = weekFour;
                break;
            case 3:
                desiredWeek = weekThree;
                break;
            case 2:
                desiredWeek = weekTwo;
                break;
            default:
                desiredWeek = weekOne;
                break;
        }
        foreach (GameObject day in desiredWeek)
        {
            day.GetComponent<DateItemActivation>().DeActivate();
        }
    }

    public void NextWeek()
    {
        Debug.Log("Next Week button clicked"+ desiredWeek);
        if (desiredWeek< MAXWEEKS)
        {
            UnHighlightWeek(desiredWeek);
            desiredWeek++;
            HighlightWeek(desiredWeek);
        }
    }

    public void PreviousWeek()
    {
        Debug.Log("Previous Week button clicked:"+ desiredWeek);
        if (desiredWeek > 0)
        {
            UnHighlightWeek(desiredWeek);
            desiredWeek--;
            HighlightWeek(desiredWeek);
        }
    }
}
