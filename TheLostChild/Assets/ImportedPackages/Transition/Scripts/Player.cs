using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static bool loadedYet = true;
    private Inventory inventory;
    public List<string> curItems;
    public List<string> takenItems;



    void Start()
    {
        GameObject curInventory = GameObject.Find("Player");
        inventory = curInventory.GetComponent<Inventory>();
        for (int i = 0;i < 5;i++)
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
                Debug.Log(inventory.itemLists[i].name);
                Debug.Log(curItems[i]);
            }
        }
        saveSystem.Save(this);
        Debug.Log("Saved");
    }

    public void loadPlayer()
    {
        SceneManager.LoadScene("Game Scene");
        loadedYet = false;
    }

    public void loadNewInfo()
    {
        loadedYet = true;
        playerData data = saveSystem.Load();
        if (data.tutorial == true)
        {
            Debug.Log("y");
            saveTrigger.instance.tutorialObject.SetActive(false);
        }
        else
        {
            
        }
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
                case null:
                    break;
            }             

        }
        

       
    }
}
