using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StayRuneSwitchScript : MonoBehaviour
{
    public DisplayCollector thisCollector;
    // Start is called before the first frame update
    void Start()
    {
        thisCollector = this.gameObject.GetComponent<DisplayCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisCollector.isCollected == true)
        {
            SceneManager.LoadScene("StayTuneScene");
        }
    }
}
