using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePromptButton : MonoBehaviour
{
    public GameObject savePrompt;
    private savePointTouch bench;


    void Start()
    {
        GameObject savePoint = GameObject.Find("Savepoint");
        bench = savePoint.GetComponent<savePointTouch>();

    }

    public void savePromptCheck()
    {
        if (bench.playerTouch)
        {
            savePrompt.SetActive(true); 
        }
        else
        {
            Debug.Log("not in range");
        }
    }

}
