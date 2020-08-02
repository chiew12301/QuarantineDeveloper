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
        public Sprite cutsceneImg;
        public float textSpeed = 0.1f;
        [TextArea(1, 10)]
        public string sentences;
        public bool isJitter;
    }

    //! preserves original state of booleans
    [System.NonSerialized]
    private bool oriHasDialogueEnd = false;


    [Header("Write down the dialogues in the scene below")]
    public bool hasDialogueEnded = false;
    public Info[] dialogueInfo;

    private void OnEnable()
    {
        hasDialogueEnded = oriHasDialogueEnd;

    }
}
