using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PuzzleDrop pD;
    BoxCollider2D col2d;
    DialogueManager Dm;
    [Header("Dont Destroy After Interact")]
    public bool DontDestroy = false;

    public bool CanInteractAgain = false;
    public bool isRiddleDone = false;

    [Header("Dialogue")]
    public bool Dialogue = false;
    public bool isMirror = false;
    public bool isMusicBox = false;
    public GameObject dialogueDisplay;
    //public GameObject dialogueManager;
    public Dialogue dialogue;
    public Dialogue dialogue2;

    [Header("Item")]
    public bool Item = false;

    public GameObject itemObtainedPanel;
    public GameObject itemButton;
    public Item item;

    [Header("Locked Item")]
    public bool isItemLocked = false;
    public GameObject lockedMessagePanel;


    [Header("Inspect Item")]
    public bool Inspect = false;
    public GameObject inspectDisplay;

    
    [Header("Others")]
    public MoveScriptTesting player;
    private float Distance;
    public MouseCursor mcS;
    //GameObject playerMovement;

    public bool isShowDialogue = false;
    public bool isItemObtain = false;

    [Header("Mouse")]
    public bool MouseisIn = false;

    [Header("Disable blocking area")]
    public bool blockingArea = false;
    public GameObject[] blockedArea;

    public bool isDestroyAfter = false;
    public GameObject itemshowafterhide;
    void Start()
    {
        mcS = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseCursor>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
        //player.OnPressLeftClick += OnPressLeftClick_Test;
        //playerMovement = GameObject.FindWithTag("Player");
        col2d = GetComponent<BoxCollider2D>();
        if(itemshowafterhide != null)
        {
            itemshowafterhide.SetActive(false);
        }

    }

    private void OnDisable()
    {
        player.OnPressLeftClick -= OnPressLeftClick_Test;
    }

    private void OnEnable()
    {
        //if (player.OnPressLeftClick != null)
        //{
        //    player.OnPressLeftClick.Invoke(player.isLeftClicked);
        //}
        player.OnPressLeftClick += OnPressLeftClick_Test;
    }

    private void Update()
    {
        calDistance(player.gameObject);
    }

    

    public void performPickup()
    {
        if(item != null)
        {
            if (item.name == "Hairpin")
            {
                MainEnemyScript.enableES = true;
            }
            if (item.name == "MusicBox")
            {
                MusicBoxScript MusicBox = this.GetComponent<MusicBoxScript>();
                if (MusicBox.counterBookDrop >= 3)
                {
                    //ok just proceed add item
                }
                else
                {
                    //dialogue for tell player needed to collect puzzle?
                    return;
                }
            }
        }
        

        if (Inventory.instance.itemLists.Count >= Inventory.instance.maxSize)
        {
            Debug.Log("Inventory is full");
            return;
        }
        else
        {
            if (Dialogue == true)
            {
                if (isMirror)
                {
                    pD = GameObject.Find("PuzzleCollector").GetComponent<PuzzleDrop>();
                    if (pD.isPuzzleDone == false)
                    {
                        dialogueDisplay.SetActive(true);
                        DialogueManager.instance.StartDialogue(dialogue);
                    }
                    else if (pD.isPuzzleDone == true)
                    {
                        dialogueDisplay.SetActive(true);
                        /*FindObjectOfType<DialogueManager>()*/
                        DialogueManager.instance.StartDialogue(dialogue2);
                        isRiddleDone = true;
                    }
                }
                else
                {
                    dialogueDisplay.SetActive(true);
                    DialogueManager.instance.StartDialogue(dialogue);
                }
            }

            if (Item == true)
            {

                Time.timeScale = 0.0001f;
                itemObtainedPanel.SetActive(true);
                player.StopMoving();
                Inventory.instance.addItem(item);
            }

            
            if (DontDestroy == false)
            {
                ObjectPoolingManager.instance.AddPoolList(this.gameObject);
            }
            else
            {
                col2d.enabled = false;
            }

            if (Inspect == false)
            {
                player.OnPressLeftClick -= OnPressLeftClick_Test;
            }


            if (CanInteractAgain == true)
            {   
                col2d.enabled = true;
                player.OnPressLeftClick += OnPressLeftClick_Test;
            }

            mcS.setToDefaultCursor("Hover");
            if (isDestroyAfter == true)
            {
                if (itemshowafterhide != null)
                {
                    itemshowafterhide.SetActive(true);
                }
                this.gameObject.SetActive(false);
            }

            if(Item == true)
            {
                col2d.enabled = true;
            }

        }
    }

    public void itemLocked()
    {
        lockedMessagePanel.SetActive(true);
        Invoke("lockedMsgDisappear", 1f);
        
    }

    public void disableBlockedArea()
    {
        Destroy(gameObject);
        blockedArea[0].SetActive(false);
        blockedArea[1].SetActive(false);
    }

    public void inspect()
    {
        inspectDisplay.SetActive(true);
        //playerMovement.GetComponent<MoveScriptTesting>().enabled = false;
        //Time.timeScale = 0;
        //MoveScriptTesting.instance.StopMoving();
        InspectScript.isItemTicked = false;

    }

    void lockedMsgDisappear()
    {
        lockedMessagePanel.SetActive(false);
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
                //Debug.Log("Done");
                if (isItemLocked)
                {
                    itemLocked();
                }
                else if (Inspect)
                {
                    inspect();
                    if(Item)
                    {
                        InspectScript.isItemTicked = true;
                        performPickup();
                        Item = false;
                        
                    }
                    col2d.enabled = true;


                }
                else if(blockingArea)
                {
                    disableBlockedArea();
                    
                }
                else
                {
                    performPickup();
                }
                
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

    public void OnPointerEnter(PointerEventData data)
    {
        mcS.setToCursorEyes("Hover");
        MouseisIn = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        mcS.setToDefaultCursor("Hover");
        MouseisIn = false;
    }

}
