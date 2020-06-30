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
    public GameObject DialogueUI;

    private Queue<Dialogue.Info> dialogueInfo = new Queue<Dialogue.Info>();
    private Queue<BubbleSpeech.Info> bubbleInfo = new Queue<BubbleSpeech.Info>();
   
    private BubbleSpeech tempBubble;

    private bool isBubble;
    public bool isDialogueTrigger = false;
    public bool isDialogueEnd = false;
    public Animator dialogueAnimator;
    public Animator bubbleAnimator;
    public Animator panelAnimator;

    private List<SpecialCommand> specialCommands;
    private VertexJitter[] jitterScript;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        DialogueUI.SetActive(true);
    }

    public void ResetDialogueChange()
    {
        tempBubble.isChanged = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start dialog");
        isBubble = false;
        dialogueAnimator.SetBool("isOpen", true);
        panelAnimator.SetBool("isOpen", true);
        dialogueInfo.Clear();

        //for each seperate info(name, portrait, dialogue text) in the list of information(dialogueInfo)....
        foreach (Dialogue.Info info in dialogue.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }
        DisplayNextSentence();

    }

    public void StartBubble(BubbleSpeech bubble)
    {
        isBubble = true;
        bubbleAnimator.SetBool("isOpen", true);
        panelAnimator.SetBool("isOpen", true);
        tempBubble = bubble;
     
        bubbleInfo.Clear();

            
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
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        Time.timeScale = 0f;
        if (isBubble)
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
        else
        {
            if (dialogueInfo.Count == 0)
            {
                EndDialogue();
                return;
            }

            Dialogue.Info info = dialogueInfo.Dequeue();
            nameText.text = info.name;
            dialoguePortrait.sprite = info.portrait;
            cutscenePanel.sprite = info.cutsceneImg;
            dialogueText.text = info.sentences;
         
            StopAllCoroutines();
            StartCoroutine(TypeSceneDialogue(info));
        }
        isDialogueEnd = true;
    }

    IEnumerator TypeSentence(BubbleSpeech.Info info)
    {
        bubbleText.text = "";
        int i = 0;
        specialCommands = BuildSpecialCommandList(info.sentences);
        string stripText = StripAllCommands(info.sentences);
        int counter = 0; //to make typewriter effect

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

        //sentence  without the <> 
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
            bubbleText.maxVisibleCharacters = counter;
            counter += 1;

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

    IEnumerator TypeSceneDialogue(Dialogue.Info info)
    {
        dialogueText.text = "";
        int i = 0;
        specialCommands = BuildSpecialCommandList(info.sentences);
        string stripText = StripAllCommands(info.sentences);
        int counter = 0; //to make typewriter effect


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

        //sentence  without the <> 
        while (true)
        {
            dialogueText.maxVisibleCharacters = counter;
            counter += 1;

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


    void EndDialogue()
    {
        dialogueAnimator.SetBool("isOpen", false);
        bubbleAnimator.SetBool("isOpen", false);
        panelAnimator.SetBool("isOpen", false);
        Time.timeScale = 1.0f;
       
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
