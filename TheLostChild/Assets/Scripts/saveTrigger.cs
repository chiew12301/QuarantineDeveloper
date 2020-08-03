using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveTrigger : MonoBehaviour
{
    public static int puzzleProgression = 0;
    public GameObject tutorialObject;
    [HideInInspector]
    public List<GameObject> itemObject = new List<GameObject>();
    public static List<bool> itemCheck = new List<bool>();
    public List<Item> itemScriptObject = new List<Item>();
    public static saveTrigger instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Start()
    {
        for (int i = 0;i < 100;i++)
        {
            itemCheck.Add(false);
        }
    }
    public void Update()
    {
        for (int j = 0; j < itemObject.Capacity; j++)
        {
            if (itemObject[j].activeInHierarchy == false)
            {
                itemCheck[j] = true;
            }

        }
        for (int i = 0;i < itemObject.Count; i++)
        {
            if (itemCheck[i])
            {
                itemObject[i].SetActive(false);
            }
        }
    }

}


