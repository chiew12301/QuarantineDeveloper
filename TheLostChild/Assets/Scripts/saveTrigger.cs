using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveTrigger : MonoBehaviour
{
    public GameObject tutorialObject;
    public List<GameObject> itemObject = new List<GameObject>();
    public static List<bool> itemCheck = new List<bool>();
    public List<Item> itemScriptObject = new List<Item>();
    public static saveTrigger instance;
    public List<GameObject> enemies = new List<GameObject>();
    [HideInInspector]
    public bool enemySpawned = false;
    public List<GameObject> hidingCases = new List<GameObject>();
    [HideInInspector]
    public bool[] hidingCaseTriggered = new bool[4];
    public List<GameObject> displayCases = new List<GameObject>();
    [HideInInspector]
    public bool[] displayCaseProgress = new bool[5];
    //public List<bool> displayCaseProgress = new List<bool>();
    [HideInInspector]
    public bool[] dialogueChecks = new bool[12];
    [HideInInspector]
    public bool checkedYet = true;
    public List<GameObject> puzzlePieces = new List<GameObject>();
    [HideInInspector]
    public bool enemyDespawner = false;
    [HideInInspector]
    public bool mapIsAvailable;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            itemCheck.Add(false);
        }
        displayCaseProgress = new bool[5];

    }
    public void Update()
    {
        if (checkedYet == false)
        {

            Debug.Log("Checking");
            //Checked means to reload in the items after loading
            //Dialogue
            dialogueCheckingFunction();
            //Enemies
            enemyCheck();
            //Items / Objects
            objectCheck();
            //Hiding Spots
            hidingCheck();
            //Display Cases
            displayCheck();
            if (!mapIsAvailable)
            {
                SetMapJournal.MapIsAvailable = false;
            }
            checkedYet = true;
        }

        //Update is to check what new changes needs to be saved/updated
        //Dialogue
        dialogueUpdate();
        //Enemies
        enemyUpdate();
        //Items / Objects
        objectUpdate();
        //Hiding Case
        hidingUpdate();
        //Display Cases
        displayUpdate();

    }

    public void dialogueCheckingFunction()
    {

        DialogueCutscene.instance.isStartCutScenePlayed = dialogueChecks[0];

        DialogueCutscene.instance.isStartConversation = dialogueChecks[1];

        DialogueCutscene.instance.isStartConversationEnd = dialogueChecks[2];


        DialogueCutscene.instance.isVSCutscenePlayed = dialogueChecks[3];

        DialogueCutscene.instance.isEnteredLobbyOnce = dialogueChecks[4];


        DialogueCutscene.instance.isExitLobby = dialogueChecks[5];


        DialogueCutscene.instance.isCutS2Played = dialogueChecks[6];


        DialogueCutscene.instance.isCutS3PlayedP1 = dialogueChecks[7];

        DialogueCutscene.instance.isCutS3PlayedP3 = dialogueChecks[8];


      //  DialogueCutscene.instance.isCutSMemPlayed = dialogueChecks[9];


        DialogueCutscene.instance.isCutSAyuLivingRPlayed = dialogueChecks[10];

     //   DialogueCutscene.instance.isRiddleP1 = dialogueChecks[11];

    }
    public void dialogueUpdate()
    {
        if (DialogueCutscene.instance.isStartCutScenePlayed)
        {
            dialogueChecks[0] = true;
        }
        if (DialogueCutscene.instance.isStartConversation)
        {
            dialogueChecks[1] = true;
        }
        if (DialogueCutscene.instance.isStartConversationEnd)
        {
            dialogueChecks[2] = true;
        }
        if (DialogueCutscene.instance.isVSCutscenePlayed)
        {
            dialogueChecks[3] = true;
        }
        if (DialogueCutscene.instance.isEnteredLobbyOnce)
        {
            dialogueChecks[4] = true;
        }
        if (DialogueCutscene.instance.isExitLobby)
        {
            dialogueChecks[5] = true;
        }
        if (DialogueCutscene.instance.isCutS2Played)
        {
            dialogueChecks[6] = true;
        }
        if (DialogueCutscene.instance.isCutS3PlayedP1)
        {
            dialogueChecks[7] = true;
        }
        if (DialogueCutscene.instance.isCutS3PlayedP3)
        {
            dialogueChecks[8] = true;
        }
        //if (DialogueCutscene.instance.isCutSMemPlayed)
        //{
        //    dialogueChecks[9] = true;
        //}
        if (DialogueCutscene.instance.isCutSAyuLivingRPlayed)
        {
            dialogueChecks[10] = true;
        }
        //if (DialogueCutscene.instance.isRiddleP1)
        //{
        //    dialogueChecks[11] = true;
        //}
    }
    public void enemyCheck()
    {
        
        if (enemySpawned)
        {
            MainEnemyScript.enableES = true;
        }
    }
    public void enemyUpdate()
    {
        if (enemies[0].activeInHierarchy)
        {
            enemySpawned = true;
        }
        else if (enemySpawned == false && enemyDespawner == false)
        {
            enemyDespawner = true;
            MainEnemyScript.enableES = false;
            enemies[0].SetActive(false);
            enemies[1].SetActive(false);
        }
    }
    public void objectCheck()
    {
        for (int i = 0; i < itemObject.Count; i++)
        {
            if (itemCheck[i])
            {
                itemObject[i].SetActive(false);
            }
        }
    }
    public void objectUpdate()
    {
        for (int j = 0; j < itemObject.Capacity; j++)
        {
            if (itemObject[j].activeInHierarchy == false)
            {
                itemCheck[j] = true;
            }
        }
    }
    public void hidingCheck()
    {
            for (int i = 0; i < 4; i++)
            {
                hidingCases[i].SetActive(hidingCaseTriggered[i]);
            }
    }
    public void hidingUpdate()
    {
        for (int i = 0; i < 4; i++)
        {
            hidingCaseTriggered[i] = hidingCases[i].activeInHierarchy;
        }
    }

    public void displayCheck()
    {
        for (int i = 0; i < displayCases.Count; i++)
        {
            displayCases[i].GetComponent<DisplayCollector>().isCollected = displayCaseProgress[i];
            if (displayCaseProgress[i])
            {
                spriteCheck(i);
            }
            else
            {

            }

            //Debug.Log(displayCases[i].GetComponent<DisplayCollector>().isCollected);
            //Debug.Log(displayCaseProgress[i]);
        }
    }
    public void displayUpdate()
    {

        for (int i = 0; i < 5; i++)
        {
            displayCaseProgress[i] = displayCases[i].GetComponent<DisplayCollector>().isCollected;
            //Debug.Log(displayCases[i].GetComponent<DisplayCollector>().isCollected);
            //Debug.Log(displayCaseProgress[i]);
        }
    }

    public void spriteCheck(int i)
    {

        Color tempColor;
        Sprite tempSprite;
        tempColor.a = 0;
        tempSprite = displayCases[i].GetComponent<DisplayCollector>().ItemCollect.GetComponent<SpriteRenderer>().sprite;
        //displayCases[i].GetComponent<DisplayCollector>().childrenSprite = displayCases[0].GetComponent<DisplayCollector>().ItemCollect.GetComponent<SpriteRenderer>().sprite;
        displayCases[i].GetComponent<DisplayCollector>().Children.GetComponent<SpriteRenderer>().sprite = tempSprite;
        tempColor = displayCases[i].GetComponent<DisplayCollector>().Children.GetComponent<SpriteRenderer>().material.color;
        tempColor.a = 1;
        displayCases[i].GetComponent<DisplayCollector>().Children.GetComponent<SpriteRenderer>().material.color = tempColor;


    }

}


