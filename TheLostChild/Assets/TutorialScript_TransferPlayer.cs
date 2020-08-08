using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript_TransferPlayer : MonoBehaviour
{
    public TransferPlayer tpScript;
    public TransferPlayer tpScript2;
    public static bool isEnable = false;
    public static bool isEnable_2 = false;
    public static bool deactive = false;
    public static bool deactive_2 = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (isEnable && !deactive)
        {
            Transfer_1();
            deactive = true;
            isEnable = false;
        }

        if(isEnable_2 && !deactive_2)
        {
            Transfer_2();
            deactive_2 = true;
            isEnable_2 = false;
        }
    }

    void Transfer_1()
    {
        tpScript.TransferPlayerToDes();
    }

    void Transfer_2()
    {
        tpScript2.TransferPlayerToDes();
    }
}






