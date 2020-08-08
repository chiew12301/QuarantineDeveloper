using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreloadCutsceneManager : MonoBehaviour
{
    public static PreloadCutsceneManager instance;

    //to stop player moving
    private MoveScriptTesting playerScript;
    public bool isCutscene = false;
    private bool loading = false;

    //to check player click in order to instantly display the sentence (work with IEnumerator (dialogue ver))
    private bool hasClicked;
    private float ClickTimer = 0.0f;
    private float ClickDelay = 0.05f;

    //to check when the sentence end
    private int sentenceCounter = 0;

    private int sentenceMaxLength;
    private int sentenceCurrentLength;

    private int prevSentenceLengthEnd;
    private int paragraphCurrentLength;
    private int paragraphMaxLength;

    private bool isSentenceEnd;

    private string[] sentenceList;
    private TextMeshProUGUI textArea;
    private GameObject tempObj;
    private Image tempImg;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
    }
    void Update()
    {

        //if (tempImg.gameObject.activeSelf ==true)
        //{
        //    tempObj.SetActive(false);
        //}

        //check if player click while sentence haven't end, work with IEnumerator(dialogue ver)
        if (Input.GetMouseButtonDown(0) && isSentenceEnd == false)
        {
            hasClicked = true;
        }

        if (hasClicked == true)
        {
            if (ClickTimer >= ClickDelay)
            {
                hasClicked = false;
                ClickTimer = 0.0f;
            }
            else
            {
                ClickTimer += Time.deltaTime;
            }
        }

        //check to see if reached the end of the sentence, work with IEnumerator(dialogue ver)
        if (sentenceCurrentLength != 0 && sentenceMaxLength != 0)
        {
            if (sentenceCurrentLength >= sentenceMaxLength)
            {
                isSentenceEnd = true;
                //Debug.Log("Sentence ended");
           }
        }

        // if end of sentence reached, and player clicks again
        if (isSentenceEnd == true && Input.GetMouseButtonDown(0))
        {
            sentenceCurrentLength = 0;
            sentenceMaxLength = 0;
            if(sentenceCounter>sentenceList.Length)
            {
                sentenceCounter = sentenceList.Length;
            }
            else
            {
                sentenceCounter += 1;
            }
            DisplayNextSentence();
            isSentenceEnd = false;
        }
    }
    public void StartParagraph(GameObject GO, Paragraph paragraph, TextMeshProUGUI txt, Image img)
    { 
        isCutscene = true;
        
       // sentenceList = new string[];

        //split per sentence
        sentenceList = paragraph.sentences.Split("-"[0]);
        textArea = txt;
        tempObj = GO;
        tempImg = img;

        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (sentenceCounter >= sentenceList.Length - 1)
        {
            sentenceCounter = 0;
           
            paragraphCurrentLength = 0;
            paragraphMaxLength = 0;
            prevSentenceLengthEnd = 0;
          
            
            if(tempImg!= null)
            {
                tempImg.gameObject.SetActive(true);
                StartCoroutine(Wait());
                
            }
            else
            {
                tempObj.SetActive(false);
                StartCoroutine(Wait2());
            }
            Debug.Log("CutsceneEnd");
            CutsceneEnd();
            isCutscene = false;

            return;
        }
       
        paragraphCurrentLength += prevSentenceLengthEnd;
       // Debug.Log(paragraphCurrentLength);
    //    StopAllCoroutines();
        StartCoroutine(TypeParagraph(sentenceList[sentenceCounter], textArea));
        prevSentenceLengthEnd = sentenceList[sentenceCounter].Length;  
    }

    IEnumerator TypeParagraph(string s, TextMeshProUGUI txt)
    {
        int counter = 0; //to make typewriter effect

          sentenceMaxLength = sentenceList[sentenceCounter].Length;

       paragraphMaxLength += s.Length;
       
            txt.text += sentenceList[sentenceCounter];
          //  Debug.Log(txt.text);
       
        
        //txt spd 
        //  float finalTxtSpd = info.textSpeed / (chgTextSpeed.instance.changedTextSpeed * 2);
        yield return new WaitForSeconds(0.05f);

        //if (hasClicked == true)
        //{
        //    sentenceCurrentLength = stripText.Length;
        //}
        //sentence  without the <> 
        while (true)
        {

            ////to see sentence reach end or not   
            sentenceCurrentLength = counter;
            paragraphCurrentLength = counter;
            txt.maxVisibleCharacters = paragraphMaxLength;//paragraphCurrentLength;//+ counter;

            if (hasClicked == true)
            {
                sentenceCurrentLength = sentenceList[sentenceCounter].Length;
                txt.maxVisibleCharacters = paragraphMaxLength;


                yield break;
            }
            else
            {

                txt.maxVisibleCharacters = paragraphMaxLength;//paragraphCurrentLength;//+ counter;

                if (counter >= paragraphMaxLength)
                {
                    counter = paragraphMaxLength;
                }
                else
                {
                    counter += 1;
                }


                yield return null;
            }
          
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        tempObj.SetActive(false);
        if (DialogueCutscene.instance.isStartCutScenePlayed == false)
        {
            DialogueCutscene.instance.isStartCutScenePlayed = true;
        }
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1.0f);
        tempObj.SetActive(false);
        if (DialogueCutscene.instance.isVSCutscenePlayedEnd == false)
        {
            DialogueCutscene.instance.isVSCutscenePlayedEnd = true;
        }
    }
    private void CutsceneEnd()
    {
        

        if(DialogueCutscene.instance.isStartConversationEnd == true && DialogueCutscene.instance.isVSCutscenePlayed == false)
        {
            if(DialogueCutscene.instance.isStartCutScenePlayed == true)
            {
                DialogueCutscene.instance.isVSCutscenePlayed = true;
            }
           
        }

      
    }
}
