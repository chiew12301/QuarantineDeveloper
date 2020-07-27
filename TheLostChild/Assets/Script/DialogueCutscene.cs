using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueCutscene : MonoBehaviour
{
    public static DialogueCutscene instance;
   

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

    [Header("VerticalSliceSummary")]
    public GameObject VSObj;
    public Paragraph VSparagraph;
    public TextMeshProUGUI VSparagraphText;
    public bool isVSCutscenePlayed = false;


    [Header("DialogueData")]
    public Dialogue dialogueMusicBox;
    public Dialogue dialogueStartScene;
    public Dialogue dialogueCutS2;
    public Dialogue dialogueCutS3;
    public Dialogue dialogueCutS3P2;
    public Dialogue dialogueCutS3P3;
    public Dialogue dailogueAyuLivingR; //not working
    public Dialogue dialogueLIG;
    public Dialogue dialogueLIG2;
    public Dialogue dialogueLIG3;
    public Dialogue dialogueRiddleP1;
    // in header dialogue data
    public Dialogue dialogueHairPin;
    [Header("DialogueCanvas")]
    public GameObject dialogueDisplay;

    [Header("Boolean")]
    private bool isMusicBox = false;
    public bool isEnteredLobbyOnce = false;
    public bool isExitLobby = false;
    public bool isCutS2Played = false;
    public bool isCutS3PlayedP1 = false;
    public bool isCutS3PlayedP2 = false;
    public bool isCutS3PlayedP3 = false;
    public bool isCutSMemPlayed = false;
    public bool isCutSAyuLivingRPlayed = false;
    public bool isCutSLIG = false;
    public bool isCutSLIG2 = false;
    public bool isCutSLIG3 = false;
    public bool isRiddleP1 = false;

    //in header boolean
    private bool pickedUpHairPin = false; //check if hairpin in inventory or not
    private bool isHairPin = false;

    public GameObject player;
    private CameraScript mainCam;

    [Header("Check")]
    public Vector3 LeftLocationLobby;
    public Vector3 RightLocationLobby;
    public Vector3 FullLeftLocationLobby;
    public Vector3 FullRightLocationLobby;
 
    [Header("Location Cutscene")]
    public Vector3 LeftLocation2;
    public Vector3 RightLocation2;
    public Vector3 LeftLocation3;
    public Vector3 RightLocation3;
    public Vector3 LeftLocationLR;
    public Vector3 RightLocationLR;
    public Vector3 LeftLocationLIG;
    public Vector3 RightLocationLIG;
    public Vector3 LeftAyuPainting;
    public Vector3 RightAyuPainting;

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
 
           //dialogueDisplay.SetActive(true);
          //DialogueManager.instance.StartDialogue(dialogueStartScene);
            
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
        //the conveersation with parents
        if(isStartCutScenePlayed == true && isStartConversation == false)
        {
            DialogueManager.instance.StartDialogue(conversationWithParent);
            isStartConversation = true;
        }

        //VSSummary
        if(isStartConversationEnd == true && isVSCutscenePlayed == false)
        {
        //    Debug.Log("HI");
            VSObj.SetActive(true);
            PreloadCutsceneManager.instance.StartParagraph(VSObj, VSparagraph, VSparagraphText, null);
            isVSCutscenePlayed = true;
        }

        if (player.transform.position.x >= LeftLocation2.x && player.transform.position.x <= RightLocation2.x)
        {
            if(player.transform.position.y <= LeftLocation2.y && player.transform.position.y >= RightLocation2.y)
            { CutScene2(); }
        }
        //Living room
        if (player.transform.position.x >= LeftLocationLR.x && player.transform.position.x <= RightLocationLR.x)
        {
            if (player.transform.position.y <= LeftLocationLR.y && player.transform.position.y >= RightLocationLR.y)
            {
                CutSceneLR();
            }
        }
        ////Lady in red gallery
        //if (player.transform.position.x >= LeftLocationLIG.x && player.transform.position.x <= RightLocationLIG.x)
        //{
        //    if (player.transform.position.y <= LeftLocationLIG.y && player.transform.position.y >= RightLocationLIG.y)
        //    {
        //        CutSceneLIG();
        //    }
        //}
        if (player.transform.position.x >= LeftLocation3.x && player.transform.position.x <= RightLocation3.x)
        {
            if (player.transform.position.y <= LeftLocation3.y && player.transform.position.y >= RightLocation3.y)
            {
                if (isEnteredLobbyOnce == true)
                { CutScene3(); }
            }
        }
        if (isExitLobby == true && isCutS3PlayedP1 == true)
        {
            CutScene3ExitLobby();
        }

        //in checkTriggerCutscene()
        if (pickedUpHairPin == true)
        {
            if (player.transform.position.x >= LeftLocationLIG.x && player.transform.position.x <= RightLocationLIG.x)
            {
                if (player.transform.position.y <= LeftLocationLIG.y && player.transform.position.y >= RightLocationLIG.y)
                {
                    HairPinCutScene();
                }
            }
        }

        //check goinfront of ayu picture
        if(isHairPin == true)
        {
            if (player.transform.position.x >= LeftAyuPainting.x && player.transform.position.x <= RightAyuPainting.x)
            {
                if (player.transform.position.y <= LeftAyuPainting.y && player.transform.position.y >= RightAyuPainting.y)
                {
                    CutSceneLIG2();
                }
            }
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
        
        //if(player.transform.position.x >= FullLeftLocationLobby.x && player.transform.position.x <= FullRightLocationLobby.x)
        //{
        //    if (player.transform.position.y >= FullLeftLocationLobby.y && player.transform.position.y <= FullRightLocationLobby.y)
        //    {
        //        isExitLobby = true;
        //    }
        //}
    }

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

    public void CutScene3ExitLobby()
    {
        if (isCutS3PlayedP2 == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueCutS3P2);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutS3PlayedP2 = true;
        }
        if (isCutS3PlayedP3 == false && isCutS3PlayedP2 == true)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueCutS3P3);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutS3PlayedP3 = true;
        }
        else { return; }
    }

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

    public void CutSceneLIG()
    {
        if (isCutSLIG == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueLIG);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutSLIG = true;
        }
        else { return; }
    }

    public void CutSceneLIG2()
    {
        if (isCutSLIG2 == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueLIG2);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutSLIG2 = true;
            CutSceneLIG3();
        }
        else { return; }
    }

    public void CutSceneLIG3()
    {
        if (isCutSLIG3 == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueLIG3);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isCutSLIG3 = true;
        }
        else { return; }
    }


    //add bfr ienumerator
    public void LIRwithHairPin()
    {
        if (pickedUpHairPin == false)
        {
            Debug.Log("PickedHairpin");
            pickedUpHairPin = true;
        }
        else
        {
            return;
        }
    }
    public void HairPinCutScene()
    {
        if (isHairPin == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueHairPin);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isHairPin = true;
        }
        else
        {
            return;
        }

    }

    //music box
    public void getMusicBox()
    {
        if (isMusicBox == false)
        {
            dialogueDisplay.SetActive(true);
            DialogueManager.instance.StartDialogue(dialogueMusicBox);
            player.GetComponent<MoveScriptTesting>().StopMoving();
            isMusicBox = true;
        }
        else { return; }
    }

}
