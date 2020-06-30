using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTouch : MonoBehaviour 
{
    public bool playerTouch = false;
    // Start is called before the first frame update

    private void Start()
    {
        playerTouch = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //Debug.Log(playerTouch);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTouch = true;
        }  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerTouch = false;
        }
    }
}
