using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectScript : MonoBehaviour
{
    public GameObject Panel;

    GameObject player;

    public static bool isItemTicked = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            if(isItemTicked == false)
            {
                Time.timeScale = 1;
                player.GetComponent<MoveScriptTesting>().enabled = true;
            }

            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }

    }

}
