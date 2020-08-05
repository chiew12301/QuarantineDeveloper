using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePointTouch : MonoBehaviour
{
    public bool playerTouch = false;
    // Start is called before the first frame update

    private void Update()
    {
        Player.touch = playerTouch;
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
