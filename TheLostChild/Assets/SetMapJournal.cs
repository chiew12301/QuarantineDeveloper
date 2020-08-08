using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetMapJournal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject MapJournalTabBig;
    public GameObject MapJournalTabSmall;
    public static bool MapIsAvailable = false;

    public Dialogue dialogue;
    public BubbleSpeech bubble;

    private Transform t;
    private Transform player;
    private bool isNear = false;
    private bool isPicked = false;
    public bool isDialogTrigger = false;
    private MouseCursor mcs;

    [Header("Item")]
    public GameObject item1;
    public GameObject item2;
    [Header("Journal")]
    public GameObject journal1;
    public GameObject journal2;

    public bool desAfterTrigger = false;

    public TransferPlayer tpScript;

    [Header("Notify Panel")]
    public bool EnablePanel = true;
    public GameObject NotifyPanelMap;

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
        MapIsAvailable = false;
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
    }

    public void TriggerDialogueSpeech()
    {
        NotifyPanelMap.SetActive(true);
        MapJournalTabBig.SetActive(true);
        MapJournalTabSmall.SetActive(true);
        MapIsAvailable = true;

        if (isDialogTrigger == true)
        {
            Debug.Log("Triggered dialog");
            DialogueManager.instance.StartDialogue(dialogue);
            //if (DialogueManager.instance.isDialogueEnd == true)
            //{
            if (tpScript != null)
            {
                tpScript.TransferPlayerToDes();
            }
            //}
            if (isPicked == false)
            {
                if (item1 != null)
                {
                    if (item1.GetComponent<PickUp>() != null)
                    {
                        item1.GetComponent<PickUp>().performPickup();
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
                this.gameObject.SetActive(false);
            }
        }
    }

    public void TriggerBubbleSpeech()
    {
        if (isNear)
        {
            DialogueManager.instance.StartBubble(bubble);
            if (isPicked == false)
            {
                if (item1 != null)
                {
                    if (item1.GetComponent<PickUp>() != null)
                    {
                        item1.GetComponent<PickUp>().performPickup();
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
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
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

    public void OnPointerDown(PointerEventData eventData)
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

    private void OnMouseEnter()
    {
        mcs.setToCursorEyes("Hover");
    }

    private void OnMouseExit()
    {
        mcs.setToDefaultCursor("Hover");
    }

    public void OnPointerEnter(PointerEventData data)
    {
        mcs.setToCursorEyes("Hover");
    }

    public void OnPointerExit(PointerEventData data)
    {
        mcs.setToDefaultCursor("Hover");
    }
}
