using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateItemActivation : MonoBehaviour
{

    public GameObject hightLightPanel;
    public GameObject eventActiveIndicator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        this.hightLightPanel.SetActive(true);
        this.transform.GetComponent<Button>().enabled = (true);
    }

    public void DeActivate()
    {
        this.hightLightPanel.SetActive(false);
        this.transform.GetComponent<Button>().enabled = (false);
    }

    public void ActivateEventIndicator()
    {
        this.eventActiveIndicator.SetActive(true);
    }

    public void Reset()
    {
        this.eventActiveIndicator.SetActive(false);
        DeActivate();
    }
}
