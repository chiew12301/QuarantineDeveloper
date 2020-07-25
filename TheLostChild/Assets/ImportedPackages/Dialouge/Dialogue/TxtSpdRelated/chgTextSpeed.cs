using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;

public class chgTextSpeed : MonoBehaviour
{
    public static chgTextSpeed instance;

    //let player choose what speed they want
    public TextMeshProUGUI shownTextSpd;
    public int txtSpdIndex = 0;
    public float changedTextSpeed = 1.0f;
    public float[] txtSpeedList = { 1.0f, 1.25f, 1.5f, 2.0f };



     private void Awake()
    {
        if (instance == null) //For Multiple Scene Purpose
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(txtSpdIndex == 0)
        {
            shownTextSpd.text = " 1.0 ";
        }
        else if(txtSpdIndex ==1)
        {
            shownTextSpd.text= " 1.25 ";
        }
        else if(txtSpdIndex ==2)
        {
            shownTextSpd.text = " 1.5 ";
        }
        else if (txtSpdIndex == 3)
        {
            shownTextSpd.text = " 2.0 ";
        }
    }

    public void NextSpd()
    {
        if (txtSpdIndex >= txtSpeedList.Length-1)
        {
            txtSpdIndex = 0;
        }else
        {
            txtSpdIndex++;
        }
        
        changedTextSpeed = txtSpeedList[txtSpdIndex];
    }

    public void PrevSpd()
    {
        
       if(txtSpdIndex <= 0)
        {
            txtSpdIndex = txtSpeedList.Length - 1;
        }
       else
        {
            txtSpdIndex--;
        }
    }
}
