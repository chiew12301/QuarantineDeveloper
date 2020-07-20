using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailPainting : MonoBehaviour
{
    public bool isReal;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Nail"))
        {
            if (!isReal)
            {           
                Debug.Log("Bad Ending");
            }
            else if (isReal)
            {
                Debug.Log("Real Ending");
            }
            collision.gameObject.SetActive(false);
        }
        else
        {
            return;
        }

    }
}
