using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicBoxSwitchSceneScript : MonoBehaviour
{
    public PickUp mirror;
    public PuzzleDrop pd;
    private MouseCursor mcS;
    public MoveScriptTesting player;
    public Item item;
    public bool MouseisIn = false;
    private float Distance;

    public GameObject dialogueDisplay;
    public Dialogue dialogue;
    private void Start()
    {
        mcS = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseCursor>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
        player.OnPressLeftClick += OnPressLeftClick_Event;
    }

    public void performPickup()
    {
        if (Inventory.instance.itemLists.Count >= Inventory.instance.maxSize)
        {
            Debug.Log("Inventory is full");
            return;
        }
            
        dialogueDisplay.SetActive(true);
        DialogueManager.instance.StartDialogue(dialogue);
        Inventory.instance.addItem(item);
        ObjectPoolingManager.instance.AddPoolList(this.gameObject);
        player.isMusicPicked = true;
        player.OnPressLeftClick -= OnPressLeftClick_Event;
        mcS.setToDefaultCursor("Hover");
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

    public void OnPressLeftClick_Event(bool f)
    {
        if (f == true)
        {
            if (calDistance(player.gameObject) <= 3 && MouseisIn == true)
            {
                if (mirror.isRiddleDone == true && pd.isPuzzleDone == true)
                {
                    performPickup();
                }
            }
            else
            {
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
