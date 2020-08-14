using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempscript : MonoBehaviour
{
    public Text txt;
    string condition;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.instance.isTalking == true)
        {
            condition = "true";
        }
        else
        {
            condition = "false";
        }
        txt.text = condition;
    }
}
