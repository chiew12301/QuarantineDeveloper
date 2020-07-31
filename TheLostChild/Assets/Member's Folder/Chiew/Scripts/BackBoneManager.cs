using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBoneManager : MonoBehaviour
{
    public static BackBoneManager instance;
    public MoveScriptTesting _playerMoveScript;
    public DialogueManager _dialogueScript;

    [HideInInspector]
    public bool stopPlayerMove = false;
    [HideInInspector]
    public bool InvenUIIsStop = false;
    [HideInInspector]
    public bool isCutScene = false;

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
    }

    public void CheckBackBone()
    {//playerScript.isStop = isCutscene;
        InvenUIIsStop = InventoryScriptUI.instance.isOpen;
        if(InvenUIIsStop == true || DialogueManager.instance.isTalking == true 
            || PreloadCutsceneManager.instance.isCutscene == true)
        {
            if(DialogueManager.instance.isTalking == true 
                || PreloadCutsceneManager.instance.isCutscene == true)
            {
                InventoryScriptUI.instance.closeInventorySlots();
                InvenUIIsStop = InventoryScriptUI.instance.isOpen;
            }
            stopPlayerMove = true;
        }
        else
        {
            stopPlayerMove = false;
        }
        _playerMoveScript.isStop = stopPlayerMove;

        isCutScene = stopPlayerMove;
    }

}
