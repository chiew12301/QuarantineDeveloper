using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalTutorialScript : MonoBehaviour
{
    public static bool isTutorial = true;

    public GameObject Panel;
    public Text TextBox;
    public GameObject Journal;
    public GameObject Block;
    public static bool gameStart = false;
    bool DontRepeat = false;
    public GameObject JournalAuto_Folder;

    bool isJournal = true;

    void Start()
    {
        StartCoroutine(StartTutorial());
    }

    void Update()
    {
        Debug.Log("Tutorial is : " + isTutorial);

        if (gameStart && !DontRepeat)
        {
            gameStart = false;
            StartCoroutine(StartGame());
            DontRepeat = true;
        }
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(5);
        Panel.SetActive(true);
        TextBox.text = "Now let's return to Lady Gallery.";
        yield return new WaitForSeconds(5);
        Panel.SetActive(false);
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4);
        Panel.SetActive(true);
        TextBox.text = "That's all for the tutorial. Good luck!";
        yield return new WaitForSeconds(2);
        Block.SetActive(false);
        yield return new WaitForSeconds(3);
        Panel.SetActive(false);
        JournalAuto_Folder.SetActive(true);
        isTutorial = false;
    }

    IEnumerator closePanel()
    {
        yield return new WaitForSeconds(7);
        Panel.SetActive(false);
    }
    IEnumerator JournalTutorial()
    {
        //player.GetComponent<MoveScriptTesting>().enabled = false;
        Panel.SetActive(true);
        Journal.SetActive(true);
        TextBox.text = "Click on Max's journal on the top right of your screen if feeling lost on what to do next.";
        yield return new WaitForSeconds(7);
        //player.GetComponent<MoveScriptTesting>().enabled = true;
        Panel.SetActive(false);
    }

    IEnumerator InventoryTutorial()
    {
        yield return new WaitForSeconds(1);
        Panel.SetActive(true);
        TextBox.text = "Hover top area to open Inventory.";
        yield return new WaitForSeconds(5);
        TextBox.text = "Items will be stored in the inventory and it can be dragged out for certain purposes.";
        yield return new WaitForSeconds(5);
        Panel.SetActive(false);
        yield return new WaitForSeconds(5);
        StartCoroutine(JournalTutorial());
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isJournal)
            {
                isJournal = false;
                StartCoroutine(InventoryTutorial());
            }
        }

    }
}
