using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public static bool isTutorial = true;

    public GameObject Panel;
    [SerializeField] TextMeshProUGUI TextBox;
    public static bool disableTutorialBlocks = false;
    public GameObject blocker_1, blocker_2;
    public GameObject JournalAuto_Folder;

    GameObject player;
    public GameObject journal;

    public GameObject journalTutorial;

    bool savePoint = true;

    public GameObject TutorialLight;

    public static bool gameStart = false;
    bool DontRepeat = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(StartTutorial());
        journal.SetActive(false);
        blocker_1.SetActive(false);
        blocker_2.SetActive(false);
        Panel.SetActive(false);
        isTutorial = true;
        DontRepeat = false;
        gameStart = false;
        JournalAuto_Folder.SetActive(false);
    }

    void Update()
    {
        if (gameStart && !DontRepeat)
        {
            gameStart = false;
            StartCoroutine(StartGame());
            DontRepeat = true;
        }

    }

    /*IEnumerator openTutorialPanel()
    {
        yield return new WaitForSeconds(3);
        Panel.SetActive(true);
        StartCoroutine(StartTutorial());
    }*/

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(2);
        Panel.SetActive(true);
        TextBox.text = "Tutorial session";
        yield return new WaitForSeconds(4);
        TextBox.text = "Move Max around by pointing your cursor anywhere on your screen and clicking your left mouse button.";
        //player.GetComponent<MoveScriptTesting>().enabled = true;
        yield return new WaitForSeconds(8);
        TextBox.text = "Your cursor changes into an Eye icon if you hover something interactable.";
        yield return new WaitForSeconds(8);
        TextBox.text = "or something that Max can pick up.";
        yield return new WaitForSeconds(8);
        Panel.SetActive(false);
        yield return new WaitForSeconds(2);
        TutorialScript_TransferPlayer.isEnable = true;
        yield return new WaitForSeconds(4);
        StartCoroutine(SavePoint());
        

        

    }

    IEnumerator SavePoint()
    {
        Panel.SetActive(true);
        TextBox.text = "Sofas are resting points where you can save your game.";
        yield return new WaitForSeconds(8);
        Panel.SetActive(false);
        yield return new WaitForSeconds(2);
        TutorialScript_TransferPlayer.isEnable_2 = true;
        yield return new WaitForSeconds(4);
        StartCoroutine(EndTutorial());
    }

    IEnumerator EndTutorial()
    {
        Panel.SetActive(true);
        TextBox.text = "Hover your mouse cursor on top of the screen and Max's inventory will pop up.";
        yield return new WaitForSeconds(8);
        TextBox.text = "You can store or drag out items from Max's Inventory.";
        yield return new WaitForSeconds(8);
        TextBox.text = "You can access Max's journal by clicking on the icon on the top right of your screen.";
        yield return new WaitForSeconds(8);
        TextBox.text = "Max's Journal gives important information to guide you if you're lost.";
        journal.SetActive(true);
    }

    IEnumerator StartGame()
    {
        TextBox.text = ".....Good Luck.....";
        yield return new WaitForSeconds(4);
        JournalAuto_Folder.SetActive(true);
        Panel.SetActive(false);
        isTutorial = false;
    }



    /*IEnumerator HeadToNextRoom()
    {
        Panel.SetActive(true);
        TextBox.text = "Now let's head to the Storeroom!";
        blocker_2.SetActive(false);
        TutorialLight.SetActive(true);
        yield return new WaitForSeconds(5);
        Panel.SetActive(false);
    }

    IEnumerator SavePointTutorial()
    {
        disableTutorialBlocks = true;
        savePoint = false;
        yield return new WaitForSeconds(1);
        Panel.SetActive(true);
        TutorialLight.SetActive(false);
        TextBox.text = "Game will be saved by clicking the sofa.";
        yield return new WaitForSeconds(4);
        TextBox.text = "So better click them when you have the chance.";
        yield return new WaitForSeconds(7);
        journalTutorial.SetActive(true);
        Panel.SetActive(false);
    }

    IEnumerator closePanel()
    {
        yield return new WaitForSeconds(7);
        Panel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (savePoint)
            {
                StartCoroutine(SavePointTutorial());
            }
        }

    }*/
}
