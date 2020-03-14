using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarSceneController : MonoBehaviour
{

    public readonly int MAXWEEKSTOFIGHT = 4;
    public static CalendarSceneController _sceneController = new CalendarSceneController();
    public readonly float MAXSLIDERVALUE = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _sceneController = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
