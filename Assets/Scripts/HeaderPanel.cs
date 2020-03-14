using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderPanel : MonoBehaviour
{

    public Slider currentStamina;
    public Text weeksToFight;
    public Text cash;
   

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetWeeksToFight((CalendarSceneController._sceneController.MAXWEEKSTOFIGHT - EventRoster._eventRosterInstance.GetSize()).ToString());
        SetStaminaSlider(((float)CalendarSceneController._sceneController.MAXWEEKSTOFIGHT - (float)EventRoster._eventRosterInstance.GetSize()) / ((float)CalendarSceneController._sceneController.MAXWEEKSTOFIGHT));
        Debug.Log(CalendarSceneController._sceneController.MAXWEEKSTOFIGHT + "" + EventRoster._eventRosterInstance.GetSize() 
            + ""+ (CalendarSceneController._sceneController.MAXWEEKSTOFIGHT - EventRoster._eventRosterInstance.GetSize())
            + "" + (((float)CalendarSceneController._sceneController.MAXWEEKSTOFIGHT - (float)EventRoster._eventRosterInstance.GetSize())/ (float)CalendarSceneController._sceneController.MAXWEEKSTOFIGHT));
    }

    void SetWeeksToFight(string text)
    {
        weeksToFight.text = text;
    }

    void SetCash(string text)
    {
        cash.text = text;
    }

    void SetStaminaSlider(float value)
    {
        Debug.Log("Value:" + value);
        currentStamina.value = value;
    }

    
}
