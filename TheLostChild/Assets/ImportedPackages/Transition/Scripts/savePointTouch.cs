using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePointTouch : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Player.touch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            Player.touch = false;
        }
    }

}
