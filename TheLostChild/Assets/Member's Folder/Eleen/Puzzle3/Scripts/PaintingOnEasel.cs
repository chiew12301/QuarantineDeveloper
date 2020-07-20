using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingOnEasel : MonoBehaviour
{
    public static PaintingOnEasel instance;

    public Sprite emptyPainting;
    public Sprite wornPainting;
    public Sprite shinyPainting;

    public SpriteRenderer curSprite;
    public bool clearedPuzzle3 = false;

    public Dialogue wPaintingOnEasel;
    public Dialogue firstPlacePainting;

    public GameObject correctBottle;
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
        if (collision.name == "Painting4")
        {
            Debug.Log("Worn painting placed");
            collision.gameObject.SetActive(false);
            curSprite.sprite = wornPainting;
            DialogueManager.instance.StartDialogue(firstPlacePainting);
        }

        if ( collision.name == "Bottle2")
        {
            Debug.Log("Correct bottle used (bottle 2)");
            if (curSprite.sprite == wornPainting)
            {
                Debug.Log("Bottle used on worn painting");
                collision.gameObject.SetActive(false);
                curSprite.sprite = shinyPainting;
            }
        }
    }


    void OnMouseDown()
    {
        if (curSprite.sprite == wornPainting)
        {
            DialogueManager.instance.StartDialogue(wPaintingOnEasel);
        }
    }
}
