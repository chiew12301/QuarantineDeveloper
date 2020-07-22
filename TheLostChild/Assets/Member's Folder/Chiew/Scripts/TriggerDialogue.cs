using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public BubbleSpeech bubble;

    private Transform t;
    private Transform player;
    private bool isNear = false;
    public bool isDialogTrigger = false;

    public GameObject item1;
    public GameObject item2;
    public bool desAfterTrigger = false;

    public TransferPlayer tpScript;

    private void Awake()
    {
        if (bubble)
        {
            t = this.transform;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (bubble)
        {
            float distance = Vector2.Distance(t.position, player.position);

            if (distance <= 3.0f)
            {
                isNear = true;
            }
            if (distance > 3.0f)
            {
                isNear = false;
            }
        }
    }

    public void TriggerDialogueSpeech()
    {
        if (isDialogTrigger == true)
        {
            Debug.Log("Triggered dialog");
            DialogueManager.instance.StartDialogue(dialogue);
            //if (DialogueManager.instance.isDialogueEnd == true)
            //{
            tpScript.TransferPlayerToDes();
            //}
            if (item1 != null)
            {
                if (item1.GetComponent<PickUp>() != null)
                {
                    item1.GetComponent<PickUp>().performPickup();
                }
            }
            if (item2 != null)
            {
                if (item2.GetComponent<PickUp>() != null)
                {
                    item2.GetComponent<PickUp>().performPickup();
                }
            }
            if (desAfterTrigger == true)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void TriggerBubbleSpeech()
    {
        if (isNear)
        {
            DialogueManager.instance.StartBubble(bubble);
            if (item1 != null)
            {
                if (item1.GetComponent<PickUp>() != null)
                {
                    item1.GetComponent<PickUp>().performPickup();
                }
            }
            if (item2 != null)
            {
                if (item2.GetComponent<PickUp>() != null)
                {
                    item2.GetComponent<PickUp>().performPickup();
                }
            }
            if (desAfterTrigger == true)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        if(dialogue != null)
        {
            TriggerDialogueSpeech();
        }
        else if (bubble != null)
        {
            TriggerBubbleSpeech();
        }
    }

}
