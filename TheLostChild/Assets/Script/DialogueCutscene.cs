using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueCutscene : MonoBehaviour
{
    public static DialogueCutscene instance;

    public GameObject player;
    private CameraScript mainCam;
    public GameObject JournalAuto_Folder;
    public Image blackScreen;

    [Header("DialogueCanvas")]
    public GameObject dialogueDisplay;

    [Header("OpeningCutscene")]
    public GameObject OPObj;
    public Paragraph OPparagraph;
    public TextMeshProUGUI OPparagraphText;
    public Image picture;
    public bool isStartCutScenePlayed = false;

    [Header("ConversationWithParentCutscene")]
    public Dialogue conversationWithParent;
    public bool isStartConversation = false;
    public bool isStartConversationEnd = false;
    public Image ParentBG;

    [Header("VerticalSliceSummary")]
    public GameObject VSObj;
    public Paragraph VSparagraph;
    public TextMeshProUGUI VSparagraphText;
    public bool isVSCutscenePlayed = false;

    [Header("First time out lady in red")]
    public Dialogue dialogueCutS2;
    public Vector3 LeftLocation2;
    public Vector3 RightLocation2;
    public bool isCutS2Played = false;

    [Header("First time enter lobby")]
    public Dialogue dialogueCutS3;
    public Vector3 LeftLocation3;
    public Vector3 RightLocation3;
    public bool isCutS3PlayedP1 = false;

    [Header("After received Hairpin")]
    public GameObject hairpin;
    public Dialogue firstTimePickupHairpin;
    private bool hasTriggeredHairpinDialogue = false;

    [Header("First time exit lobby - enemy spawn dialogue")]
    //for check enter lobby once
    public Vector3 FullLeftLocationLobby;
    public Vector3 FullRightLocationLobby;
    public bool isEnteredLobbyOnce = false;
    public bool isExitLobby = false;
    //enemy dialogue
    public Dialogue dialogueCutS3P3;
    public bool isCutS3PlayedP3 = false;

    [Header("After put hairpin in display case")]
    public GameObject hairpinInDisplayCase;
    public Dialogue dialogueHairPinDisplay;
    private bool hasTriggeredHairpinInDisplayCase = false;

    [Header("First time enter seal room 1")]
    public Dialogue dailogueAyuLivingR;
    public Vector3 LeftLocationLR;
    public Vector3 RightLocationLR;
    public bool isCutSAyuLivingRPlayed = false;

    [Header("Puzzle3related")]
    public Dialogue dialoguePuzzle3;
    private bool hasTriggeredPuzzle3Cutscene = false;
    private bool hasTriggeredFinP3Cutscene = false;
    public TransferPlayer tpScript;
    public PickUp pickUpBottle;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        //starting cutscene
        if (isStartCutScenePlayed == false)
        {
            OPObj.SetActive(true);
            PreloadCutsceneManager.instance.StartParagraph(OPObj, OPparagraph, OPparagraphText, picture);
        }
        else
        {
            return;
        }
        mainCam = GameObject.Find("Main Camera").GetComponent<CameraScript>();

    }

    private void Update()
    {
        checkEnterOnce();
        CheckTriggerCutScene();
    }

    void CheckTriggerCutScene()
    {

        //while all opening cutscene hasnt played fin, leave a black screen to prevent player from seeing game
        if(isVSCutscenePlayed == false)
        {
            blackScreen.gameObject.SetActive(true);
        }
        else
        {
            blackScreen.gameObject.SetActive(false);
        }

        //the conveersation with parents
        if(isStartCutScenePlayed == true && isStartConversation == false)
        {
            ParentBG.gameObject.SetActive(true);
            DialogueManager.instance.StartDialogue(conversationWithParent);
            isStartConversation = true;
        }

        //VSSummary
        if(isStartConversationEnd == true && isVSCutscenePlayed == false)
        {
            //    Debug.Log("HI");
            ParentBG.gameObject.SetActive(false);
            VSObj.SetActive(true);
            PreloadCutsceneManager.instance.StartParagraph(VSObj, VSparagraph, VSparagraphText, null);
            isVSCutscenePlayed = true;

            //for new note - journal
            JournalAuto_Folder.SetActive(true);
        }

        ////first time receive hairpin
        if (player.transform.position.x >= -11 && player.transform.position.x <= 8)
        {
            if (player.transform.position.y >= 1  && player.transform.position.y <= 2)
            {
                if (hasTriggeredHairpinDialogue == false)
                { FirstTimeHairPin(); }
            }
        }

        //first time put hairpin in
        if(hairpinInDisplayCase.GetComponent<DisplayCollector>().isCollected == true )
        {
            if(hasTriggeredHairpinInDisplayCase == false)
            {
                HairPininCase();
            }
        }

        //check if finished puzzle3 dialogue
        if(PaintingOnEasel.instance.afterCleanPainting.hasDialogueEnded ==true)
        {
            Puzzle3Cutscene();
        }

        //transport player when puzzle 3 end
        if(dialoguePuzzle3.hasDialogueEnded ==true)
        {
            Puzzle3TransportPlayer();
        }

        //first time out lady in red
        if (player.transform.position.x >= LeftLocation2.x && player.transform.position.x <= RightLocation2.x)
        {
            if(player.transform.position.y <= LeftLocation2.y && player.transform.position.y >= RightLocation2.y)
            { CutScene2(); }
        }

        //First enter seal room 1
        if (player.transform.position.x >= LeftLocationLR.x && player.transform.position.x <= RightLocationLR.x)
        {
            if (player.transform.position.y <= LeftLocationLR.y && player.transform.position.y >= RightLocationLR.y)
            {
                CutSceneLR();
            }
        }
       
        //first time in lobby
        if (player.transform.position.x >= LeftLocation3.x && player.transform.position.x <= RightLocation3.x)
        {
            if (player.transform.position.y <= LeftLocation3.y && player.transform.position.y >= RightLocation3.y)
            {
                if (isEnteredLobbyOnce == true)
                { CutScene3(); }
            }
        }

        //first time out lobby -  enemy spawn 
        if (isExitLobby == true && isCutS3PlayedP1 == true)
        {
            CutScene3ExitLobby();
        }
    }

    public void checkEnterOnce()
    {
        if (player.transform.position.x >= FullLeftLocationLobby.x && player.transform.position.x <= FullRightLocationLobby.x)
        {
            if (player.transform.position.y <= FullLeftLocationLobby.y && player.transform.position.y >= FullRightLocationLobby.y)
            { isEnteredLobbyOnce = true; isExitLobby = false; }
            else
            { isExitLobby = true; }
        }
        
    }

    //first time out lady in red
    public void CutScene2()
    {
        if (isCutS2Played == false)
        {       
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueCutS2);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutS2Played = true;
        }
        else { return; }
    }

    //first time in lobby
    public void CutScene3()
    {
        if (isCutS3PlayedP1 == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueCutS3);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutS3PlayedP1 = true;
        }
        else { return; }
        
    }

    //FirstTimeHairPin
    public void FirstTimeHairPin()
    {
        if (hairpin.activeSelf == false && hasTriggeredHairpinDialogue == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(firstTimePickupHairpin);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            hasTriggeredHairpinDialogue = true;
        }
        else { return; }

    }

    //first time out lobby -  enemy spawn 
    public void CutScene3ExitLobby()
    {

        if (isCutS3PlayedP3 == false && MainEnemyScript.enableES == true )
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueCutS3P3);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutS3PlayedP3 = true;
        }
        else { return; }
        GetJournalNoteAuto.getNote5 = true;
    }

    //first time put hairpin in display case
    public void HairPininCase()
    {
        if (hasTriggeredHairpinInDisplayCase == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueHairPinDisplay);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            hasTriggeredHairpinInDisplayCase = true;
        }
        else { return; }
    }

    //first enter seal room 1
    public void CutSceneLR()
    {
        if (isCutSAyuLivingRPlayed == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dailogueAyuLivingR);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutSAyuLivingRPlayed = true;
        }
        else { return; }
    }

    //after puzzle3 dialogue end - the cutscene plays
    public void Puzzle3Cutscene()
    {
        if (hasTriggeredPuzzle3Cutscene == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialoguePuzzle3);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            hasTriggeredPuzzle3Cutscene = true;
        }
        else { return; }
    }

    //after fin puzzle3 cutscene
    public void Puzzle3TransportPlayer()
    {
        if (hasTriggeredFinP3Cutscene == false)
        {
            if (tpScript != null)
            {
                tpScript.TransferPlayerToDes();
                hasTriggeredFinP3Cutscene = true;
                pickUpBottle.performPickup();
                pickUpBottle.itemObtainedPanel.SetActive(false); 
            }         
        }
        else { return; }
        GetJournalNoteAuto.getNote11 = true;
    }

}
