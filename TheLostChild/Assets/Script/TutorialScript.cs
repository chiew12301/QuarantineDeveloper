using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject Panel;
    public Text leftClickText;
    public static bool disableTutorialBlocks = false;
    public GameObject blocker_1, blocker_2;

    GameObject player;
    GameObject journal;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<MoveScriptTesting>().enabled = false;
        StartCoroutine(openTutorialPanel());
        journal = GameObject.FindWithTag("Journal");
        journal.SetActive(false);

    }


    void Update()
    {
        if(disableTutorialBlocks)
        {
            blocker_1.SetActive(false);
            blocker_2.SetActive(false);
        }
    }

    IEnumerator openTutorialPanel()
    {
        
        yield return new WaitForSeconds(3);
        Panel.SetActive(true);
        player.GetComponent<MoveScriptTesting>().enabled = true;
        StartCoroutine(LeftClickTutorial());
    }

    IEnumerator LeftClickTutorial()
    {
        yield return new WaitForSeconds(3);
        journal.SetActive(true);
        leftClickText.text = "Click on Max's journal on the top right of your screen if feeling lost on what to do next.";
        StartCoroutine(closePanel());
    }

    IEnumerator closePanel()
    {
        yield return new WaitForSeconds(3);
        Panel.SetActive(false);
    }
}
