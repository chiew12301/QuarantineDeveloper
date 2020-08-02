using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingOnEasel : MonoBehaviour
{
    public static PaintingOnEasel instance;

    public GameObject emptyPainting;
    public Sprite wornPainting;
    public Sprite shinyPainting;

    public SpriteRenderer curSprite;
    public bool clearedPuzzle3 = false;

//    public Dialogue wPaintingOnEasel;
    public Dialogue firstPlacePainting;
    public Dialogue afterCleanPainting;

    public GameObject correctPainting;
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if worn painting is placed
        if (collision.tag == "CorrectPainting")//"CorrectPainting(Outside)")
        {
            Debug.Log("Worn painting placed");
            collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<PickUp>().enabled = false;
            emptyPainting.GetComponent<SpriteRenderer>().sprite = wornPainting;
          //  curSprite.sprite = wornPainting;
            DialogueManager.instance.StartDialogue(firstPlacePainting);
        }

        if ( collision.tag == "CorrectBottle")
        {
            Debug.Log("Correct bottle used (bottle 2)");
            if (emptyPainting.GetComponent<SpriteRenderer>().sprite == wornPainting)
            {
                Debug.Log("Bottle used on worn painting");
                collision.gameObject.SetActive(false);
                emptyPainting.GetComponent<SpriteRenderer>().sprite = shinyPainting;
                DialogueManager.instance.StartDialogue(afterCleanPainting);
                //   curSprite.sprite = shinyPainting;
            }
        }
    }


    //void OnMouseDown()
    //{
    //    if (emptyPainting.GetComponent<SpriteRenderer>().sprite == wornPainting)
    //    {
    //        DialogueManager.instance.StartDialogue(wPaintingOnEasel);
    //    }
    //}
}
