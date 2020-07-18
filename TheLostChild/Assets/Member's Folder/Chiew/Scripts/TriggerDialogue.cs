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
        //if (item1 != null)
        //{ item1.gameObject.SetActive(false); }
        //if (item2 != null)
        //{ item2.gameObject.SetActive(false); }
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
            if(DialogueManager.instance.isDialogueEnd == true)
            {
                tpScript.TransferPlayerToDes();
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
                item1.gameObject.SetActive(true);
                item1.gameObject.transform.position = this.transform.position;
            }
            if (item2 != null)
            {
                item2.gameObject.SetActive(true);
                item2.gameObject.transform.position = this.transform.position;
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
