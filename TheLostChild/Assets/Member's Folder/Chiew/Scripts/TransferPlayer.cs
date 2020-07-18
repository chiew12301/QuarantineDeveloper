using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPlayer : MonoBehaviour
{
    [Header("Player Info")]
    public GameObject playerObj;
    public Vector3 Des;
    private bool isEnterOnce = false;
    [Header("Dialogue")]
    public bool haveDialogue = false;
    public Dialogue dialogue;
    public bool haveBubble = false;
    public BubbleSpeech bubble;

    public void AtFirstEnter()
    {
        if(playerObj.transform.position == Des)
        {
            TriggerDialogueBubble();
            isEnterOnce = true;
        }
    }

    public void TriggerDialogueBubble()
    {
        if(haveDialogue == true)
        {
            if(dialogue != null)
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

    public void TransferPlayerToDes()
    {
        playerObj.transform.position = Des;
        AtFirstEnter();
    }

}
