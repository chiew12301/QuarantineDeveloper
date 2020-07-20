using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1.0f;
    private doorTouch door;
    public GameObject designatedDoor;
    private GameObject player = null;
    private Vector3 newLocation;
    public string doorName;

    private MoveScriptTesting playerScript;
    private bool isTransfering = false;
    private bool isPressed = false;

    private void Start()
    {
        GameObject d = GameObject.Find(doorName);
        door = d.GetComponent<doorTouch>();
        player = GameObject.Find("Player");
        newLocation.x = designatedDoor.transform.position.x;
        newLocation.y = designatedDoor.transform.position.y;
        playerScript = player.GetComponent<MoveScriptTesting>();
    }

    private void Update()
    {
        if (isTransfering == true)
        {
            playerScript.isStop = isTransfering;
            playerScript.StopMoving();
        }

    }
    public void changeArea()
    {
        if (door.playerTouch && isPressed == false)
        {
            Debug.Log("yes");
            isPressed = true;
            isTransfering = true;
            transition.SetTrigger("Start");
            StartCoroutine(LoadArea());     
        }
    }

    IEnumerator LoadArea()
    {

        yield return new WaitForSeconds(transitionTime);
        Debug.Log("No");
        player.transform.position = new Vector3(newLocation.x, newLocation.y);
        isTransfering = false;
        isPressed = false;
        playerScript.isStop = isTransfering;
    }

}
