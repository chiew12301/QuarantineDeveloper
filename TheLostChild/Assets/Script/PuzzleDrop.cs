using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDrop : MonoBehaviour
{
    public int counterBookDrop = 0;
    public bool isPuzzleDone = false;

    //private DialogueCutscene DCS;

    private void Start()
    {
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
