using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedMessage : MonoBehaviour
{
    public GameObject Panel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Time.timeScale = 1;
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }
}
