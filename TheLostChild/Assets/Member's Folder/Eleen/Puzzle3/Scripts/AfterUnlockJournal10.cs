using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterUnlockJournal10 : MonoBehaviour
{
    public static AfterUnlockJournal10 instance;

    public GameObject table;
    public GameObject paintingInScene;
    public GameObject bfrPickUpNote;
    public GameObject afterPickUpNote;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        afterPickUpNote.SetActive(false);
        paintingInScene.GetComponent<TriggerDialogue>().enabled = false;
        paintingInScene.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        if(table.activeSelf == false)
        {
            bfrPickUpNote.SetActive(false);
            afterPickUpNote.SetActive(true);
            paintingInScene.GetComponent<TriggerDialogue>().enabled = true;
            paintingInScene.GetComponent<BoxCollider2D>().enabled = true;

        }

    }

}
