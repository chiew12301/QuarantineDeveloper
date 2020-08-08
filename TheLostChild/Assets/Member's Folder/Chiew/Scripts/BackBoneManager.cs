using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoneManager : MonoBehaviour
{
    public static BackBoneManager instance;
    public MoveScriptTesting _playerMoveScript;
    public DialogueManager _dialogueScript;
    public JournalScript _journalScript;

    [HideInInspector]
    public bool stopPlayerMove = false;
    [HideInInspector]
    public bool InvenUIIsStop = false;
    [HideInInspector]
    public bool isCutScene = false;
    [HideInInspector]
    public bool isTransfering = false;

    void Awake()
    {
        if (instance == null) //For Multiple Scene Purpose
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckBackBone();

        if(TutorialScript.isTutorial == true)
        {
            isTransfering = true;    // <- enable when tutorial is on in DialogueCutscene.cs [Tutorial.SetActive(true);]
        }
        else if (TutorialScript.isTutorial == false)
        {
            isTransfering = false;
        }

        if (MoveScriptTesting.isPlayerDead == true)
        {
            isTransfering = true;
        }
    }

    public void CheckBackBone()
    {//playerScript.isStop = isCutscene;
        InvenUIIsStop = InventoryScriptUI.instance.isOpen;
        if(InvenUIIsStop == true || DialogueManager.instance.isTalking == true 
            || PreloadCutsceneManager.instance.isCutscene == true ||isTransfering == true || 
            checkTFJournal() == false)
        {
            if(DialogueManager.instance.isTalking == true 
                || PreloadCutsceneManager.instance.isCutscene == true || isTransfering == true 
                || checkTFJournal() == false)
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

}
