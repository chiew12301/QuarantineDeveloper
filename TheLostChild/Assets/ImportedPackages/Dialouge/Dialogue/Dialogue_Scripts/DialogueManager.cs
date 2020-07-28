using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

//need to still work with save and load manager on saving/ reverting the changed dialogues
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Image dialoguePortrait;
    public Image cutscenePanel;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI bubbleText;

    //so that the GO wont block programmers view when coding
    public GameObject DialogueUI;

    private Queue<Dialogue.Info> dialogueInfo = new Queue<Dialogue.Info>();
    private Queue<BubbleSpeech.Info> bubbleInfo = new Queue<BubbleSpeech.Info>();

    //this for obj that has diff lines when second interaction (bubble)
    private BubbleSpeech tempBubble;

    public bool isTalking;
    private bool isBubble;
    public bool isDialogueTrigger = false;
    public bool isDialogueEnd = false;

    //to check player click in order to instantly display the sentence (work with IEnumerator (dialogue ver))
    private bool hasClicked;
    private float ClickTimer = 0.0f;
    private float ClickDelay = 0.1f;

    //to check when the sentence end
    private int sentenceMaxLength;
    private int sentenceCurrentLength;
    private bool isSentenceEnd;

    //open close text boxes
    public Animator dialogueAnimator;
    public Animator bubbleAnimator;
    public Animator panelAnimator;

    //to stop player moving
    private MoveScriptTesting playerScript;

    //for jittering and extra custom effects -- scroll btm
    private List<SpecialCommand> specialCommands;
    private VertexJitter[] jitterScript;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
    }

    void Start()
    {
        DialogueUI.SetActive(true);
    }

    void Update()
    {
        playerScript.isStop = isTalking;
        if (isTalking == true)
        {
            playerScript.StopMoving();
        }

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
            }
        }

        // if end of sentence reached, and player clicks again
        if (isSentenceEnd == true && Input.GetMouseButtonDown(0))
        {
            sentenceCurrentLength = 0;
            sentenceMaxLength = 0;
            DisplayNextSentence();
            isSentenceEnd = false;
        }
    }

    public void ResetDialogueChange()
    {
        tempBubble.isChanged = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start dialog");

        isTalking = true;
        isBubble = false;
        isDialogueEnd = false;

        //clear out previously queued lines
        dialogueInfo.Clear();

        dialogueAnimator.SetBool("isOpen", true);
        panelAnimator.SetBool("isOpen", true);
        

        //for each seperate info(name, portrait, dialogue text) in the list of information(dialogueInfo)....
        foreach (Dialogue.Info info in dialogue.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        ////to display the firstmost sentence, or not it will load the default dialogue text placeholder
        DisplayNextSentence();

    }

    public void StartBubble(BubbleSpeech bubble)
    {
        isTalking = true;
        isBubble = true;

        //clear out previously queued lines
        bubbleInfo.Clear();

        //open the img
        bubbleAnimator.SetBool("isOpen", true);
        panelAnimator.SetBool("isOpen", true);
        tempBubble = bubble;

        //if only want to trigger once      
        if (bubble.onlyOnce)
            {
                if (bubble.alreadyTriggered)
                {
                    EndDialogue();
                }
                else
                {
                    foreach (BubbleSpeech.Info sentence in tempBubble.bubbleInfo)
                    {
                        bubbleInfo.Enqueue(sentence);

                    }
                    bubble.alreadyTriggered = true;
                }
            }
            else if (tempBubble.isChanged)
            {
                foreach (BubbleSpeech.Info sentence in tempBubble.changedInfo)
                {
                    bubbleInfo.Enqueue(sentence);
                }
            }
            else
            {
                foreach (BubbleSpeech.Info sentence in tempBubble.bubbleInfo)
                {
                    bubbleInfo.Enqueue(sentence);

                }
            }

        //to display the firstmost sentence
        DisplayNextSentence();

    }

    //Display next is shared by both bubble and dialogue
    public void DisplayNextSentence()
    {
        if (isBubble) // if it is bubble box
        {
            if (bubbleInfo.Count == 0)
            {
                EndDialogue();
                return;
            }

            BubbleSpeech.Info info = bubbleInfo.Dequeue();
            bubbleText.text = info.sentences;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(info));
        }
        else // if it is dialogue box
        {
            if (dialogueInfo.Count == 0)
            {
                isDialogueEnd = true;
                EndDialogue();
                return;
            }

            Dialogue.Info info = dialogueInfo.Dequeue();
            nameText.text = info.name;
            dialoguePortrait.sprite = info.portrait;
            cutscenePanel.sprite = info.cutsceneImg;
            dialogueText.text = info.sentences;

            Debug.Log(info.sentences);
            StopAllCoroutines();
            StartCoroutine(TypeSceneDialogue(info));
        }
    }

    //typewriting effect for bubble
    IEnumerator TypeSentence(BubbleSpeech.Info info)
    {
        bubbleText.text = "";
        int i = 0;
        specialCommands = BuildSpecialCommandList(info.sentences);
        string stripText = StripAllCommands(info.sentences);
        int counter = 0; //to make typewriter effect

        sentenceMaxLength = stripText.Length;

        yield return new WaitForSeconds(0.1f);

        //sentence without the {} special commands
        while (i < stripText.Length)
        {
            if (specialCommands.Count > 0)
            {
                CheckForCommands(i);
            }
            bubbleText.text += stripText[i];
            i++;
        }

        if (hasClicked == true)
        {
            sentenceCurrentLength = stripText.Length;
        }

        //sentence  without the <> 
        while (true)
        {
            //to see sentence reach end or not   
            sentenceCurrentLength = counter;
            bubbleText.maxVisibleCharacters = counter;

            //wat is this -- i didnt add this -Eleen
            //if (Input.GetMouseButtonDown(0))
            //{
            //    yield return null;
            //}
            if (hasClicked == true)
            {
                sentenceCurrentLength = stripText.Length;
                bubbleText.maxVisibleCharacters = sentenceCurrentLength;

                if (info.isJitter)
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.Start();
                    }
                }
                else
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.StopAllCoroutines();
                    }
                }
                yield break;
            }
            else
            {
                bubbleText.maxVisibleCharacters = counter;

                if (counter >= stripText.Length)
                {
                    counter = stripText.Length;
                }
                else
                {
                    counter += 1;
                }

                if (info.isJitter)
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.Start();
                    }
                }
                else
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.StopAllCoroutines();
                    }
                }

                yield return null;
            }
        }
    }

    //typewriting effect for dialogue box
    IEnumerator TypeSceneDialogue(Dialogue.Info info)
    {
        dialogueText.text = "";
        int i = 0;
        specialCommands = BuildSpecialCommandList(info.sentences);
        string stripText = StripAllCommands(info.sentences);
        int counter = 0; //to make typewriter effect

        sentenceMaxLength = stripText.Length;
        //txt spd 
        float finalTxtSpd = info.textSpeed / (chgTextSpeed.instance.changedTextSpeed * 4);

        yield return new WaitForSeconds(0.1f);

        //sentence without the {} special commands
        while (i < stripText.Length)
        {
            if (specialCommands.Count > 0)
            {
                CheckForCommands(i);
            }
            dialogueText.text += stripText[i];
            i++;
        }

        if (hasClicked == true)
        {
            sentenceCurrentLength = stripText.Length;
        }

        //sentence  without the <> 
        while (true)
        {
            //to see sentence reach end or not   
            sentenceCurrentLength = counter;
            dialogueText.maxVisibleCharacters = counter;

            if (hasClicked == true)
            {
                sentenceCurrentLength = stripText.Length;
                dialogueText.maxVisibleCharacters = sentenceCurrentLength;

                if (info.isJitter)
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.Start();
                    }
                }
                else
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.StopAllCoroutines();
                    }
                }
                yield break;
            }
            else
            {

                dialogueText.maxVisibleCharacters = counter;

                if (counter >= stripText.Length)
                {
                    counter = stripText.Length;
                }
                else
                {
                    counter += 1;
                }

                if (info.isJitter)
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.Start();
                    }
                }
                else
                {
                    jitterScript = Object.FindObjectsOfType<VertexJitter>();
                    foreach (VertexJitter jitter in jitterScript)
                    {
                        jitter.StopAllCoroutines();
                    }
                }
                yield return new WaitForSeconds(finalTxtSpd);
            }
        }
    }

    //ends the dialogue
    void EndDialogue()
    {
        isTalking = false;
        dialogueAnimator.SetBool("isOpen", false);
        bubbleAnimator.SetBool("isOpen", false);
        panelAnimator.SetBool("isOpen", false);
        
      //  Time.timeScale = 1.0f;
        ItemObtainedScript.instance.ClosePanel();

        if (DialogueCutscene.instance.isStartConversation == true)
        {
            DialogueCutscene.instance.isStartConversationEnd = true;
        }

    }

    //!!! Extra fancy stuff : colours and effects
    class SpecialCommand
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
        public int Index
        {
            get; set;
        }

        public SpecialCommand()
        {
            Name = "";
            Values = new List<string>();
            Index = 0;
        }
    }

    //! Take away command from dialogue lines
    //! 2 strings: 1 with command, one with none(shown on screen)
    private string StripAllCommands(string text)
    {
        string cleanString;

        string pattern = "\\{.[^}]+\\}";

        cleanString = Regex.Replace( text, pattern,"");
        return cleanString;
    }

    //! Stores all command
    private List<SpecialCommand>BuildSpecialCommandList(string text)
    {
        List<SpecialCommand> listCommand = new List<SpecialCommand>();

        string command = "";
        char[] bracket = { '{', '}' };

        for(int i = 0; i<text.Length;i++)
        {
            string currentChar = text[i].ToString();

                if (currentChar == "{")
                {
                    while (currentChar != "}" && i < text.Length)
                    {
                        currentChar = text[i].ToString();
                        command += currentChar;
                        text = text.Remove(i, 1); //this to check next char in the string
                    }


                    if (currentChar == "}")
                    {
                        command = command.Trim(bracket);
                        SpecialCommand newCommand = GetSpecialCommand(command);
                        newCommand.Index = i;
                        //! reset
                        listCommand.Add(newCommand);
                        command = "";

                        //so that no characters are skipped
                        i--;
                    }
                    else
                    {
                        Debug.Log("Command in dialogue line not closed.");
                    }
                }
        }
        return listCommand;
    }

    //! Extract name and value of the command {command:value}
    private SpecialCommand GetSpecialCommand(string text)
    {
        SpecialCommand newCommand = new SpecialCommand();
        string commandRegex = "[:]";

        string[] matches = Regex.Split(text, commandRegex);

        if(matches.Length>0)
        {
            for(int i = 0; i<matches.Length; i++)
            {
                if(i == 0)
                {
                    newCommand.Name = matches[i];
                }
                else
                {
                    newCommand.Values.Add(matches[i]);
                }
            }
        }
        else
        {
            return null;
        }
        return newCommand;
    }

    //! check all commands in a given index; possible to have 2 side by side and both will share same index
    private void CheckForCommands(int index)
    {
        for(int i = 0; i<specialCommands.Count; i++)
        {
            if(specialCommands[i].Index == index)
            {
                ExecuteCommand(specialCommands[i]);
                specialCommands.RemoveAt(i);

                //otherwise the script will skip one command
                i--;
            }
        }
    }

    //! Execute commands
    //! Add sound effects here
    private void ExecuteCommand(SpecialCommand command)
    {
        if (command ==null)
        {
            return;
        }
        Debug.Log("Command " + command.Name + " executing.");
        if (command.Name == "sound")
        {
            Debug.Log("Sound is played.");
        }
        if (command.Name == "change")
        {
            tempBubble.isChanged = true;
            Debug.Log("Change");
        }
        if (command.Name == "!change")
        {
            tempBubble.isChanged = false;
            Debug.Log("Change revert.");
        }

    }

}
