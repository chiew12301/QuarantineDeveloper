using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerDialogue : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Dialogue dialogue;
    public BubbleSpeech bubble;

    private Transform t;
    private Transform player;
    private bool isNear = false;
    private bool isPicked = false;
    public bool isDialogTrigger = false;
    private bool isPlayed = false;
    private MouseCursor mcs;

    [Header("Item")]
    public GameObject item1;
    public GameObject item2;
    [Header("Journal")]
    public GameObject journal1;
    public GameObject journal2;

    public bool desAfterTrigger = false;
    public bool isLastCollector = false;
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
        mcs = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseCursor>();
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
        Checking();
    }

    public void TriggerDialogueSpeech()
    {
        if (isDialogTrigger == true)
        {
            isPlayed = true;
            Debug.Log("Triggered dialog");
            DialogueManager.instance.StartDialogue(dialogue);
        }
    }

    public void TriggerBubbleSpeech()
    {
        if (isNear)
        {
            isPlayed = true;
            DialogueManager.instance.StartBubble(bubble);
        }
    }

    void Checking()
    {
        if(isPlayed == true)
        {
            if (DialogueManager.instance.isTalking == false)
            {
                isPlayed = false;
                if (tpScript != null)
                {
                    tpScript.TransferPlayerToDes();
                }
                if (isLastCollector == true)
                {
                    this.GetComponent<LastCollectorScript>().JumpScareActivate();
                }
            }
            if (isPicked == false)
            {
                if (item1 != null)
                {
                    if (item1.GetComponent<PickUp>() != null)
                    {
                        item1.GetComponent<PickUp>().performPickup();
                        isPicked = true;
                    }
                    if (item1.GetComponent<MusicBoxSwitchSceneScript>() != null)
                    {
                        item1.GetComponent<MusicBoxSwitchSceneScript>().performPickup();
                        isPicked = true;
                    }
                }
                if (item2 != null)
                {
                    if (item2.GetComponent<PickUp>() != null)
                    {
                        item2.GetComponent<PickUp>().performPickup();
                        isPicked = true;
                    }
                    if (item2.GetComponent<MusicBoxSwitchSceneScript>() != null)
                    {
                        item2.GetComponent<MusicBoxSwitchSceneScript>().performPickup();
                        isPicked = true;
                    }
                }
                if (journal1 != null)
                {
                    if (journal1.GetComponent<UnlockJournalPage>() != null)
                    {
                        journal1.GetComponent<UnlockJournalPage>().performPickup();
                        isPicked = true;
                    }
                }
                if (journal2 != null)
                {
                    if (journal2.GetComponent<UnlockJournalPage>() != null)
                    {
                        journal2.GetComponent<UnlockJournalPage>().performPickup();
                        isPicked = true;
                    }
                }
            }
            if (desAfterTrigger == true)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.SetActive(false);
            }
        }      
    }

    private void OnMouseDown()
    {
        if(BackBoneManager.instance.isCutScene == false)
        {
            if (dialogue != null)
            {
                TriggerDialogueSpeech();
            }
            else if (bubble != null)
            {
                TriggerBubbleSpeech();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (BackBoneManager.instance.isCutScene == false)
        {
            if (dialogue != null)
            {
                TriggerDialogueSpeech();
            }
            else if (bubble != null)
            {
                TriggerBubbleSpeech();
            }
        }
    }

    private void OnMouseEnter()
    {
        if (BackBoneManager.instance.isCutScene == false)
        {
            mcs.setToCursorEyes("Hover");
        }
    }

    private void OnMouseExit()
    {
        if (BackBoneManager.instance.isCutScene == false)
        {
            mcs.setToDefaultCursor("Hover");
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (BackBoneManager.instance.isCutScene == false)
        {
            mcs.setToCursorEyes("Hover");
        }
        else
        {
            mcs.setToDefaultCursor("Hover");
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (BackBoneManager.instance.isCutScene == false)
        {
            mcs.setToDefaultCursor("Hover");
        }
        else
        {
            mcs.setToDefaultCursor("Hover");
        }
    }

}
