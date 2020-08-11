using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferPlayer : MonoBehaviour
{
    public LoadingScript loadingObj;
    [Header("Player Info")]
    public GameObject playerObj;
    public Vector3 Des;
    private bool isEnterOnce = false;
    [Header("Dialogue")]
    public bool haveDialogue = false;
    public Dialogue dialogue;
    public bool haveBubble = false;
    public BubbleSpeech bubble;

    [Header("Just to solve Puzzle 3")]
    public GameObject Journal12;
    public void Start()
    {
        isEnterOnce = false;
    }

    public void AtFirstEnter()
    {
        AudioManager.instance.Play("Teleport");
        playerObj.transform.position = Des;
        if (playerObj.transform.position == Des)
        {
             TriggerDialogueBubble();
             isEnterOnce = true;
            if(Journal12 != null)
            {
                if(Journal12.GetComponent<UnlockJournalPage>() != null)
                {
                    Journal12.GetComponent<UnlockJournalPage>().performPickup();
                }
            }
        }
    }

    public void TriggerDialogueBubble()
    {
        if(isEnterOnce == false)
        {
            if (haveDialogue == true)
            {
                if (dialogue != null)
                {
                    DialogueManager.instance.StartDialogue(dialogue);
                }
            }
            if (haveBubble == true)
            {
                if (bubble != null)
                {
                    DialogueManager.instance.StartBubble(bubble);
                }
            }
        } 
    }

    public void TransferPlayerToDes()
    {
        loadingObj.gameObject.SetActive(true);
        loadingObj.onLoading(this);
    }

}
