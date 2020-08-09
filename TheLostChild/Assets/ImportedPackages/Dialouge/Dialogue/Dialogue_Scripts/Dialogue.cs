using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName ="Dialogues")]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public string name;
        public Sprite portrait;
        public bool isJitter;

        public bool isHide;
        public bool isFade;

        public float FadeBGTimer = 1.0f;
        public float textSpeed = 0.1f;
        [Header("isFadePreviousBG used together with FadeBGTimer and secondCutsceneImg")]
        public Sprite cutsceneImg;
        public Sprite secondCutsceneImg;

        [TextArea(1, 10)]
        public string sentences;
        
        
    }

    //! preserves original state of booleans
    [System.NonSerialized]
    private bool oriHasDialogueEnd = false;


    [Header("Write down the dialogues in the scene below")]
    [Header("If u just want a blank part with sfx use {} command (check DialogueManager), and type a blank space and remember to tick isHide")]
    public bool hasDialogueEnded = false;
    public Info[] dialogueInfo;

    private void OnEnable()
    {
        hasDialogueEnded = oriHasDialogueEnd;

    }
}
