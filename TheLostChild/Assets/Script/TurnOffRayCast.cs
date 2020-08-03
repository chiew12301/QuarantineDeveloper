using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffRayCast : MonoBehaviour
{
    private doorTouch dtscript;

    public Camera MainCam;
    public Component ok;
    
    private void Start()
    {
        dtscript = this.GetComponent<doorTouch>();
    }

    private void Update()
    {
        CheckAndDisable();
    }

    public void CheckAndDisable()
    {
        if(dtscript.playerTouch == true)
        {
            ;
        }
    }

}
