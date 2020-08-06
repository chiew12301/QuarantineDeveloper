using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePromptButton : MonoBehaviour
{
    public GameObject savePrompt;
    public string savePointName;


    public void savePromptCheck()
    {
        if (Player.touch)
        {
            savePrompt.SetActive(true); 
        }
        else
        {
            Debug.Log("not in range");
        }
    }

}
