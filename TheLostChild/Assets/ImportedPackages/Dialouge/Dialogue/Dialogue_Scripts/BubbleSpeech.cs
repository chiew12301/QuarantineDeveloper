using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Bubble", menuName = "Bubbles")]


public class BubbleSpeech : ScriptableObject
{
    //! hide from editor
    [System.NonSerialized]
    public bool isChanged;
    [System.NonSerialized]
    public bool onlyOnce;
    [System.NonSerialized]
    public bool alreadyTriggered;

    [System.Serializable]
    public class Info
    {
        [TextArea(1, 10)]
        public string sentences;
        public bool isJitter;
    }

    //! to return to original state
    public bool getIsChanged {  get { return isChanged; } }
    public bool getOnlyOnce { get { return onlyOnce; } }
    public bool getTriggered { get { return alreadyTriggered; } }


    //! preserves original state of booleans
    [System.NonSerialized]
    public bool oriIsChanged;
    [System.NonSerialized]
    private bool oriAlreadyTriggered;
    [Header("If you don't want it to pop again, cannot work with {change}")]
    public bool oriOnlyOnce; 
 

    [Header("Write down the bubble speech below")]
    public Info[] bubbleInfo;

    [Header("Write down the changed speech below")]
    public Info[] changedInfo;

    //! when object is loaded, this function is called
   private void OnEnable()
    {
        isChanged = oriIsChanged;
        onlyOnce = oriOnlyOnce;
        alreadyTriggered = oriAlreadyTriggered;

    }
}
