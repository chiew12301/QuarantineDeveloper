using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePromptButton : MonoBehaviour
{
    public GameObject savePrompt;
    private GameObject savePoint;
    private bool touch;
    public string savePointName;


    void Start()
    {
        savePoint = GameObject.Find(savePointName);
    }

    private void Update()
    {
        touch = savePoint.GetComponent<savePointTouch>().playerTouch;
        
    }

    public void savePromptCheck()
    {
        if (touch)
        {
            Debug.Log(touch);
            savePrompt.SetActive(true); 
        }
        else
        {
            Debug.Log("not in range");
        }
    }

}
