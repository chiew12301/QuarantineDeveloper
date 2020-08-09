using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private bool journalLoad = false;
    playerData data;


    void Start()
    {
        GameObject curInventory = GameObject.Find("Player");
        inventory = curInventory.GetComponent<Inventory>();
        for (int i = 0;i < curItems.Count;i++)
        {
            curItems[i] = null;
        }
        journalLoad = false;


    }

    void Update()
    {
        if (loadedYet == false || journalLoad == true)
        {
            loadNewInfo();
        }
        playerData data = saveSystem.Load();
        for (int i = 0; i < 12; i++)
        {
            if (data.journalArrows[i])
            {
                JournalScript.enableArrows[i] = true;
            }
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
            Debug.Log("Saved");
        }      

    }

    public void loadPlayer()
    {
        string path = Application.persistentDataPath + "/player.Data";
        if (File.Exists(path))
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                Debug.Log(journalLoad);
                Time.timeScale = 0;
                SceneManager.LoadScene("Loading Scene");
        
                loadedYet = false;
                journalLoad = true;
                Time.timeScale = 1;
                Debug.Log(journalLoad);

                //Inventory.instance.itemLists.Clear();

                //Debug.Log(Inventory.instance.itemLists[0].name);


                //curItems.Clear();
                //loadNewInfo();
                //transition.SetActive(false);
                //transition.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Loading Scene");
                loadedYet = false;


            }



        }
        else
        {

        }

       
    }

    IEnumerator loadDelay()
    {
        yield return new WaitForSeconds(2f);
        loadedYet = false;
    }

    public void loadNewInfo()
    {
        Debug.Log("loaded");
        if (journalLoad)
        {
            loadedYet = false;
        }
        else
        {
            loadedYet = true;
        }
        TutorialScript.gameStart = true ;
        TutorialScript.isTutorial = false;
        journal.SetActive(true);
        saveTrigger.instance.checkedYet = false;
        playerData data = saveSystem.Load();
        //JournalScript.enableArrows = data.journalArrows;
        JournalScript.currentPage = data.journalNotes;
        SetMapJournal.MapIsAvailable = data.map;
        saveTrigger.instance.mapIsAvailable = data.map;
        saveTrigger.instance.enemySpawned = data.enemySpawned;
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
                    saveTrigger.instance.puzzlePieces[0].GetComponent<PickUp>().performPickup();
                    break;
                case "Music Box":
                    saveTrigger.instance.puzzlePieces[1].GetComponent<PickUp>().performPickup();
                    break;
                case "Photograph":
                    saveTrigger.instance.puzzlePieces[2].GetComponent<PickUp>().performPickup();
                    break;
                case "CorrectBottle":
                    saveTrigger.instance.puzzlePieces[3].GetComponent<PickUp>().performPickup();
                    break;
                case "Bullets":
                    saveTrigger.instance.puzzlePieces[4].GetComponent<PickUp>().performPickup();
                    break;
                case null:
                    break;
            }
            saveTrigger.instance.puzzlePieces[0].GetComponent<PickUp>().itemObtainedPanel.SetActive(false);
        }
        

       
    }
}
