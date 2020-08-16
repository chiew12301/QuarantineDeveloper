using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCredits : MonoBehaviour
{
    public Dialogue credits;
    void Start()
    {
        DialogueManager.instance.StartDialogue(credits);
    }

}
