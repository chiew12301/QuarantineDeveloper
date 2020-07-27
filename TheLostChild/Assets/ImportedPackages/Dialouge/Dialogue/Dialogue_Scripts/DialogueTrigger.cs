using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    private MouseCursor mcs;

    private void Awake()
    {
        if(bubble)
        {
            t = this.transform;
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Start()
    {
        if(item1 != null)
        { item1.gameObject.SetActive(false); }
        if (item2 != null)
        { item2.gameObject.SetActive(false); }

        mcs = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseCursor>();
    }

    private void Update()
    {
        if(bubble)
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

    public void TriggerDialogue()
    {
        if (isDialogTrigger == true)
        {
            if (isNear)
            {
                Debug.Log("Triggered dialog");
                DialogueManager.instance.StartDialogue(dialogue);
            }
        }
    }

    public void TriggerBubble()
    {
        if(isNear)
        {
            DialogueManager.instance.StartBubble(bubble);
            if (item1 != null)
            { item1.gameObject.SetActive(true); }
            if (item2 != null)
            { item2.gameObject.SetActive(true); }
            if (desAfterTrigger == true)
            {
                this.gameObject.SetActive(false);
            }
        }
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




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
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
        if (item1 != null)
        { item1.gameObject.SetActive(false); }
        if (item2 != null)
        { item2.gameObject.SetActive(false); }
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

    public void TriggerDialogue()
    {
        if (isDialogTrigger == true)
        {
            Debug.Log("Triggered dialog");
            DialogueManager.instance.StartDialogue(dialogue);
        }
    }

    public void TriggerBubble()
    {
        if (isNear)
        {
            DialogueManager.instance.StartBubble(bubble);
            if (item1 != null)
            { item1.gameObject.SetActive(true); }
            if (item2 != null)
            { item2.gameObject.SetActive(true); }
            if (desAfterTrigger == true)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

}
*/