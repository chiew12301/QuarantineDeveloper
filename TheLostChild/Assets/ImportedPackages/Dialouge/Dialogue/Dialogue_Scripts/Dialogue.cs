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
        [TextArea(1, 10)]
        public string sentences;
        public bool isJitter;
    }

    [Header("Write down the dialogues in the scene below")]
    public Info[] dialogueInfo;
}
