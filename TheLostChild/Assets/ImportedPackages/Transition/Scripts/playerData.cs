﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class playerData
{
    public float[] position;
    public string[] savedItems;
    public string[] takenItems;
    public int puzzleProgress;
    public bool tutorial;
    public List<bool> checking = new List<bool>();

    public playerData(Player player)
    {
        tutorial = saveTrigger.instance.tutorialPassed;
        puzzleProgress = saveTrigger.puzzleProgression;
        takenItems = new string[player.takenItems.Count + 1];
        savedItems = new string[5];
        checking = saveTrigger.itemCheck;
        position = new float[3];
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
