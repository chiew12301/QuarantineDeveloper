using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScripts : MonoBehaviour
{
    private MoveScriptTesting pS;
    public bool isBang = false;

    private void Start()
    {
        pS = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
    }

    private void OnPressLeftClick_Event(bool f)
    {
        if (isBang == true)
        {
            pS.StopMoving();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pS.StopMoving();
            isBang = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isBang = false;
        }
    }

    private void OnMouseEnter()
    {
        pS.OnPressLeftClick += OnPressLeftClick_Event;
    }

    private void OnMouseExit()
    {
        pS.OnPressLeftClick -= OnPressLeftClick_Event;
    }

}
