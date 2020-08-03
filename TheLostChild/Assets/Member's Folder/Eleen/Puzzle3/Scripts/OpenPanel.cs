using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public static OpenPanel instance;
    public GameObject window;
    public GameObject bottle2;
    public GameObject artworkDialogues;
    public bool hasPickedUpBottle;
    private Transform t;
    private Transform player;

    private MoveScriptTesting playerScript;
    // Update is called once per frame

    void Awake()
    {
            if (instance != null)
            {
                return;
            }
            instance = this;
    
        window.SetActive(false);

        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
    }
    void Update()
    {
        if (hasPickedUpBottle == true)
        {
            bottle2.SetActive(false);

        }

        if (window.activeSelf == true)
        {
            playerScript.StopMoving();
        }
        //else
        //{
        //    bottle2.SetActive(false);
        //}
    }
    private void OnMouseDown()
    {
        Open();
    }
    public void Open()
    {
        //  playerScript.StopMoving();

        if (hasPickedUpBottle == true)
        {
            bottle2.SetActive(false);
        }
        else if (hasPickedUpBottle == false)
        {
            bottle2.SetActive(true);

        }
        window.SetActive(true);
        artworkDialogues.SetActive(false);
    }

    public void Close()
    {
       // playerScript.StopMoving();
        window.SetActive(false);
        artworkDialogues.SetActive(true);
        if(hasPickedUpBottle == true || hasPickedUpBottle == false)
        {
            bottle2.SetActive(false);
        }
    }
}
