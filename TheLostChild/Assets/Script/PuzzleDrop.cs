using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDrop : MonoBehaviour
{
    public int counterBookDrop = 0;
    public bool isPuzzleDone = false;

    public Sprite completedSprite;
    public Sprite IncompletedSprite;

    //private DialogueCutscene DCS;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = IncompletedSprite;
        //DCS = GameObject.Find("StartDialogueManager").GetComponent<DialogueCutscene>();
    }

    private void Update()
    {
        CheckBookDrop();
    }

    void CheckBookDrop()
    {
        if (counterBookDrop >= 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = completedSprite;
            isPuzzleDone = true;
            Debug.Log("Done Puzzle");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jigsaw"))
        {
            counterBookDrop++;
            Debug.Log("Counter" + counterBookDrop);
            collision.gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
