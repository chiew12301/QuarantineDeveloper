using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class sceneChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator transition;
    private float transitionTime = 1.0f;
    private doorTouch door;
    public GameObject designatedDoor;
    private GameObject player = null;
    private Vector3 newLocation;
    public string doorName;

    [Header("Assign for cursor")]
    public string StairUpOrDown = null;
    public string RoomUpOrDown = null;

    private MouseCursor mcs;
    private MoveScriptTesting playerScript;
    private bool isTransfering = false;
    private bool isPressed = false;

    private void Start()
    {
        mcs = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseCursor>();
        GameObject d = GameObject.Find(doorName);
        door = d.GetComponent<doorTouch>();
        player = GameObject.Find("Player");
        newLocation.x = designatedDoor.transform.position.x;
        newLocation.y = designatedDoor.transform.position.y;
        playerScript = player.GetComponent<MoveScriptTesting>();
    }

    private void Update()
    {

    }

    public void changeArea()
    {
        if (door.playerTouch && isPressed == false)
        {
            isPressed = true;
            playerScript.StopMoving();
            BackBoneManager.instance.isTransfering = true;
            transition.SetTrigger("Start");
            StartCoroutine(LoadArea());     
        }
    }

    IEnumerator LoadArea()
    {

        yield return new WaitForSeconds(transitionTime);

        player.transform.position = new Vector3(newLocation.x, newLocation.y);
        BackBoneManager.instance.isTransfering = false;
        isPressed = false;
    }

    private void OnMouseEnter()
    {
        if(StairUpOrDown == "None")
        {
            if(RoomUpOrDown == null)
            {
                mcs.setToCursorEyes("Hover");
                return;
            }
            else if(RoomUpOrDown == "Up")
            {
                mcs.setToCursorRoom("Up","Hover");
                return;
            }
            else if (RoomUpOrDown == "Down")
            {
                mcs.setToCursorRoom("Down", "Hover");
                return;
            }
            else if (RoomUpOrDown == "Left")
            {
                mcs.setToCursorRoom("Left", "Hover");
                return;
            }
            else if (RoomUpOrDown == "Right")
            {
                mcs.setToCursorRoom("Right", "Hover");
                return;
            }
            else
            {
                mcs.setToCursorEyes("Hover");
                return;
            }
        }
        else if(StairUpOrDown == "Up")
        {
            mcs.setToCursorStair("Up", "Hover");
            return;
        }
        else if (StairUpOrDown == "Down")
        {
            mcs.setToCursorStair("Down", "Hover");
            return;
        }
        else
        {
            mcs.setToCursorEyes("Hover");
            return;
        }
    }

    private void OnMouseExit()
    {
        mcs.setToDefaultCursor("Hover");
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (BackBoneManager.instance.isCutScene == false)
        {
            if (StairUpOrDown == "None")
            {
                if (RoomUpOrDown == null)
                {
                    mcs.setToCursorEyes("Hover");
                    return;
                }
                else if (RoomUpOrDown == "Up")
                {
                    mcs.setToCursorRoom("Up", "Hover");
                    return;
                }
                else if (RoomUpOrDown == "Down")
                {
                    mcs.setToCursorRoom("Down", "Hover");
                    return;
                }
                else if (RoomUpOrDown == "Left")
                {
                    mcs.setToCursorRoom("Left", "Hover");
                    return;
                }
                else if (RoomUpOrDown == "Right")
                {
                    mcs.setToCursorRoom("Right", "Hover");
                    return;
                }
                else
                {
                    mcs.setToCursorEyes("Hover");
                    return;
                }
            }
            else if (StairUpOrDown == "Up")
            {
                mcs.setToCursorStair("Up", "Hover");
                return;
            }
            else if (StairUpOrDown == "Down")
            {
                mcs.setToCursorStair("Down", "Hover");
                return;
            }
            else
            {
                mcs.setToCursorEyes("Hover");
                return;
            }

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
