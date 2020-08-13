using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class playerData
{
    public float[] position = new float[3];
    public string[] savedItems = new string[5];
    public string[] takenItems;
    public bool map;
    public int puzzleProgress;
    public bool tutorial;
    public bool[] journalArrows = new bool[12];
    public int[] journalNotes = new int[12];
    public bool[] hidingCases = new bool[4];
    public bool[] displayCases = new bool[5];
    public bool[] cutsceneChecks = new bool[10];
    public List<bool> checking = new List<bool>();
    public bool enemySpawned;
    public int journalPages;

    public playerData(Player player)
    {
        enemySpawned = saveTrigger.instance.enemySpawned;
        map = SetMapJournal.MapIsAvailable;
        journalArrows = JournalScript.enableArrows;
        journalNotes = JournalScript.currentPage;
        journalPages = JournalScript.p;
        tutorial = TutorialScript.disableTutorialBlocks;
        takenItems = new string[player.takenItems.Count + 1];
        checking = saveTrigger.itemCheck;
        hidingCases = saveTrigger.instance.hidingCaseTriggered;
        displayCases = saveTrigger.instance.displayCaseProgress;
        cutsceneChecks = saveTrigger.instance.cutsceneChecks;
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        for (int i = 0; i < player.curItems.Count; i++)
        {
            if (player.curItems != null)
            {
                Debug.Log(player.curItems[i]);
                savedItems[i] = player.curItems[i];
            }
            else if (player.curItems == null)
            {
                savedItems[i] = null;
            }
           
        }
        for (int i = 0; i < player.takenItems.Count; i++)
        {
            if (player.curItems != null)
            {
                takenItems[i] = player.takenItems[i];
            }

        }

    }

   
}
