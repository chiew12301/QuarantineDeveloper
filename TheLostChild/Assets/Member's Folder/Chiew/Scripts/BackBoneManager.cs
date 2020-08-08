using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoneManager : MonoBehaviour
{
    public static BackBoneManager instance;
    public MoveScriptTesting _playerMoveScript;
    public DialogueManager _dialogueScript;
    public JournalScript _journalScript;
    public GameObject[] savePointActivator;

    [HideInInspector]
    public bool stopPlayerMove = false;
    [HideInInspector]
    public bool InvenUIIsStop = false;
    [HideInInspector]
    public bool isCutScene = false;
    [HideInInspector]
    public bool isTransfering = false;
    [HideInInspector]
    public bool isTutorial = false;

    void Awake()
    {
        if (instance == null) //For Multiple Scene Purpose
        {
            instance = this;
        }
    }

    private void Start()
    {
        stopPlayerMove = false;
        InvenUIIsStop = false;
        isCutScene = false;
        isTransfering = false;
        isTutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBackBone();
        SaveActivatorCheck();

        if (TutorialScript.isTutorial == true)
        {
            isTutorial = true;    // <- enable when tutorial is on in DialogueCutscene.cs [Tutorial.SetActive(true);]
        }
        else if (TutorialScript.isTutorial == false)
        {
            isTutorial = false;
        }

        if (MoveScriptTesting.isPlayerDead == true)
        {
            isTutorial = true;
        }
    }

    public void CheckBackBone()
    {//playerScript.isStop = isCutscene;
        InvenUIIsStop = InventoryScriptUI.instance.isOpen;
        if(InvenUIIsStop == true || DialogueManager.instance.isTalking == true 
            || PreloadCutsceneManager.instance.isCutscene == true ||isTransfering == true || 
            checkTFJournal() == false || isTutorial == true)
        {
            if(DialogueManager.instance.isTalking == true 
                || PreloadCutsceneManager.instance.isCutscene == true || isTransfering == true 
                || checkTFJournal() == false || isTutorial == true)
            {
                InventoryScriptUI.instance.closeInventorySlots();
                InvenUIIsStop = InventoryScriptUI.instance.isOpen;
            }
            _playerMoveScript.StopMoving();
            stopPlayerMove = true;
        }
        else
        {
            stopPlayerMove = false;
        }
        _playerMoveScript.isStop = stopPlayerMove;

        isCutScene = stopPlayerMove;
    }

    bool checkTFJournal()
    {
        if(_journalScript.JournalButton.interactable == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void SaveActivatorCheck()
    {
        if(isCutScene == true)
        {
            foreach(GameObject savepoint in savePointActivator)
            {
                savepoint.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject savepoint in savePointActivator)
            {
                savepoint.gameObject.SetActive(true);
            }
        }
    }

}
