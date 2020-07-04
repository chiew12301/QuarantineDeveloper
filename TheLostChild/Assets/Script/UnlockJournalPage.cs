using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockJournalPage : MonoBehaviour
{
    [Header("Dialogue")]
    public bool Dialogue = false;
    public GameObject dialogueDisplay;
    public Dialogue dialogue;

    [Header("Item")]
    public bool Item = false;

    public GameObject itemObtainedPanel;
    public GameObject itemButton;
    public Item item;

    [Header("Others")]
    public MoveScriptTesting player;
    private float Distance;
    private MouseCursor mcS;
    //GameObject playerMovement;

    public bool isShowDialogue = false;
    public bool isItemObtain = false;

    [Header("Mouse")]
    public bool MouseisIn = false;

    [Header("Journal Pages To Unlock [2 - 9]")]
    public int PageNumber = 0;

    int a = 0;
    int totalA = 0;
    bool runAgain = true;


    void Start()
    {
        mcS = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseCursor>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
        player.OnPressLeftClick += OnPressLeftClick_Test;
    }

    private void OnDisable()
    {
        player.OnPressLeftClick -= OnPressLeftClick_Test;
    }

    private void OnEnable()
    {
        if (player.OnPressLeftClick != null)
        {
            player.OnPressLeftClick.Invoke(player.isLeftClicked);
        }
        player.OnPressLeftClick += OnPressLeftClick_Test;
    }

    private void Update()
    {
        calDistance(player.gameObject);
    }

    bool isSecondRound = false;

    public void performPickup()
    {
        if (isSecondRound)
        {
            JournalScript.p -= 2;
        }

        JournalScript.p += 2;
        /*JournalScript.p -= 1;
        JournalScript.p += 1;*/
        isSecondRound = true;
        ;
        if (Dialogue == true)
            {
                dialogueDisplay.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }

            if (Item == true)
            {

                itemObtainedPanel.SetActive(true);

            }


        Inventory.instance.addItem(item);

        player.OnPressLeftClick -= OnPressLeftClick_Test;

        ObjectPoolingManager.instance.AddPoolList(this.gameObject);
        mcS.setToDefaultCursor("Hover");

        switch (PageNumber)
        {
            case 2:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                
                break;
            case 3:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                break;
            case 4:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                break;
            case 5:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                break;
            case 6:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                break;
            case 7:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                break;
            case 8:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                break;
            case 9:
                JournalScript.p -= 1;
                Debug.Log("Curernt p: " + JournalScript.p);
                JournalScript.currentPage[JournalScript.p] = PageNumber-1;
                JournalScript.enableArrows[JournalScript.p] = true;
                Debug.Log("Page number found: " + PageNumber);
                break;
            default:
                print("Incorrect");
                break;
        }
        
        
        
    }

    public float calDistance(GameObject playerObject)
    {
        Distance = Vector2.Distance(this.gameObject.transform.position, playerObject.transform.position);
        return Distance;
    }

    void OnMouseEnter()
    {
        //Debug.Log("Mouse is in");
        mcS.setToCursorEyes("Hover");
        MouseisIn = true;
    }

    
    private void OnPressLeftClick_Test(bool f)
    {
        //StartCoroutine(timerDelay(2f));
        if (f == true)
        {
            if (calDistance(player.gameObject) <= 3 && MouseisIn == true)
            {
                    performPickup();
            }
            else
            {
                //Debug.Log("Not clicking or not in range");
                mcS.setToDefaultCursor("Hover");
                return;
            }

        }
    }

    void OnMouseExit()
    {
        mcS.setToDefaultCursor("Hover");
        MouseisIn = false;
    }
}
