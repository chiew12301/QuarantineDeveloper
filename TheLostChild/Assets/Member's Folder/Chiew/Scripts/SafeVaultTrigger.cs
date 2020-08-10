using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeVaultTrigger : MonoBehaviour
{
    public VetScript vs;
    public GameObject svUI;
    public GameObject cameras;
    public MoveScriptTesting player;

    private void OnMouseDown()
    {
        OpenTheUI();
    }

    public void OpenTheUI()
    {
        if(vs.isCollected == true)
        {
            if(svUI != null)
            { 
                svUI.SetActive(true);
                cameras.SetActive(false);
                Time.timeScale = 0.00001f;
            }
        }
    }

    public void SVUIOff()
    {
        svUI.SetActive(false);
        Time.timeScale = 1f;
        player.StopMoving();
    }

}
