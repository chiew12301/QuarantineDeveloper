using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle4CutsceneCheck : MonoBehaviour
{
    public void OnMouseDown()
    {
        DialogueCutscene.instance.hasTriggeredPuzzle4Cutscene = true;
    }
}
