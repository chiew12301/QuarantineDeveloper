using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MusicBoxScript : MonoBehaviour
{
    public int counterBookDrop = 0;

    public bool isUnlocked = false;
    public GameObject BarrierGallery1;

    Item i;

    private void Update()
    {
        if(this.gameObject.name == "PuzzleCollector")
        {
            CheckBookDrop();
        }
        else
        {
            DisableBlockingPath();
        }
    }

    void CheckBookDrop()
    {
        if(counterBookDrop >=3)
        {

            //Debug.Log("Done Puzzle");
        }

        
    }

    void DisableBlockingPath()
    {
        if (isUnlocked == true)
        {
            BarrierGallery1.SetActive(false);   
        }
        else
        {
            BarrierGallery1.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Jigsaw"))
        {
            counterBookDrop++;
            //Debug.Log("Counter" + counterBookDrop);
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Item") && GameObject.Find("Hairpin"))
        {
            isUnlocked = true;
            collision.gameObject.SetActive(false);
        }

    }
}
