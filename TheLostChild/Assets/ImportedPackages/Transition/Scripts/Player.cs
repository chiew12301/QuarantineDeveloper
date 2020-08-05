using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static bool touch;
    [HideInInspector]
    public static bool loadedYet = true;
    private Inventory inventory;
    public List<string> curItems;
    public List<string> takenItems;
    public GameObject transition;
    public GameObject journal;



    void Start()
    {
        GameObject curInventory = GameObject.Find("Player");
        inventory = curInventory.GetComponent<Inventory>();
        for (int i = 0;i < curItems.Count;i++)
        {
            curItems[i] = null;
        }
    }

    void Update()
    {
        if (loadedYet == false)
        {
            loadNewInfo();
        }
    }

    public void savePlayer()
    {
        if (touch)
        {
            curItems.Clear();
            takenItems.Clear();
            if (inventory.itemLists.Count == 0)
            {
                Debug.Log("Its empty");
            }
            else
            {
                for (int i = 0; i < inventory.itemLists.Count; i++)
                {
                    if (inventory.itemLists[i].itemSprite != null)
                    {
                        curItems.Add(inventory.itemLists[i].name);
                        takenItems.Add(curItems[i]);
                    }
                }
            }
            saveSystem.Save(this);
        }      

    }

    public void loadPlayer()
    {
        if (SceneManager.GetActiveScene().name == "Game Scene")
        {
            journal.GetComponent<JournalScript>().ExitJournal();
            Inventory.instance.itemLists.Clear();
            curItems.Clear();
            loadNewInfo();
            transition.SetActive(false);
            transition.SetActive(true);            
        }
        else
        {
            SceneManager.LoadScene("Loading Scene");
            loadedYet = false;
        }
       
    }

    public void loadNewInfo()
    {
        loadedYet = true;
        saveTrigger.instance.checkedYet = false;
        playerData data = saveSystem.Load();
        JournalScript.enableArrows = data.journalArrows;
        JournalScript.currentPage = data.journalNotes;
        SetMapJournal.MapIsAvailable = data.map;
        saveTrigger.instance.enemySpawned = data.enemySpawned;
        TutorialScript.disableTutorialBlocks = data.tutorial;
        saveTrigger.instance.hidingCaseTriggered = data.hidingCases;
        saveTrigger.instance.displayCaseProgress = data.displayCases;
        saveTrigger.instance.dialogueChecks = data.dialogueChecks;

        transform.position = new Vector3(data.position[0], data.position[1]);
        for (int i = 0;i < 5;i++)
        {
            Debug.Log(data.savedItems[i]);
            if (data.savedItems[i] != null)
            {
                curItems.Add(data.savedItems[i]);
            }
            else
            {
                curItems.Add(null);
            }
        }
           
        saveTrigger.itemCheck = data.checking;
        for (int i = 0;i < 5;i++)
        {
            switch (curItems[i])
            {
                case "Hairpin":
                    Inventory.instance.addItem(saveTrigger.instance.itemScriptObject[0]);
                    break;
                case "Music Box":
                    Inventory.instance.addItem(saveTrigger.instance.itemScriptObject[1]);
                    break;
                case "Photograph":
                    Inventory.instance.addItem(saveTrigger.instance.itemScriptObject[2]);
                    break;
                case "CorrectBottle":
                    Inventory.instance.addItem(saveTrigger.instance.itemScriptObject[3]);
                    break;
                case "Bullets":
                    Inventory.instance.addItem(saveTrigger.instance.itemScriptObject[4]);
                    break;
                case null:
                    break;
            }             

        }
        

       
    }
}
