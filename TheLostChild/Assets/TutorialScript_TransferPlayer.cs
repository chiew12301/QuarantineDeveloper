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
        isEnable = false;
        isEnable_2 = false;
        deactive = false;
        deactive_2 = false;
    }


    void Update()
    {
        if (isEnable && !deactive)
        {
            Transfer_1();
            deactive = true;
        }

        if(isEnable_2 && !deactive_2)
        {
            Transfer_2();
            deactive_2 = true;
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






