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
    }

    void SetWeeksToFight(string text)
    {
        weeksToFight.text = text;
    }

    void SetCash(string text)
    {
        cash.text = text;
    }

    
}
