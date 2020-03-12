using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateItemActivation : MonoBehaviour
{
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
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.transform.GetComponent<Button>().enabled = (true);
    }

    public void DeActivate()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetComponent<Button>().enabled = (false);
    }
}
