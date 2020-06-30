using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JournalScript : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;

    public GameObject []Notes;

    [Header("Buttons")]
    public Button JournalButton;
    public Button PrevButton;
    public Button NextButton;

    [Header("Pages")]
    public GameObject PrevPage;
    public GameObject NextPage;
    private int Page = 1;

    public static bool EnablePage2 = false;
    public static bool EnablePage3 = false;
    public static bool EnablePage4 = false;
    public static bool EnablePage5 = false;
    public static bool EnablePage6 = false;
    public static bool EnablePage7 = false;
    public static bool EnablePage8 = false;
    public static bool EnablePage9 = false;

    [Header("Note Tabs")]    //Journal Tabs
    public GameObject NoteDetails;
    public GameObject NoteTab;
    public GameObject NoteTabBig;
    public Button NoteTabSmall;

    [Header("Setting Tabs")]    //Journal Tabs
    public GameObject SettingsDetails;
    public GameObject SettingsTab;
    public GameObject SettingsTabBig;
    public Button SettingsTabSmall;

    MoveScriptTesting player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MoveScriptTesting>();
    }

    void Update()
    {
        pageVisibility();
    }
    public void ExitJournal()
    {
        TutorialScript.disableTutorialBlocks = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        ResetNotes();
        JournalButton.interactable = true;
        //player.GetComponent<MoveScriptTesting>().enabled = true;
    }

    public void OpenJournal()
    {
        //player.GetComponent<MoveScriptTesting>().enabled = false;
        //MoveScriptTesting.instance.StopMoving();

        OpenNoteTab();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0001f;
        player.StopMoving();
        GameisPaused = true;

        Notes[0].SetActive(true);
        Notes[1].SetActive(false);

        //PrevButton.Select();
        JournalButton.interactable = false;

        Page = 1;
    }

    public void OpenNoteTab()
    {
        NoteTab.SetActive(false);
        NoteTabBig.SetActive(true);
        SettingsTabBig.SetActive(false);
        SettingsTab.SetActive(true);

        NoteDetails.SetActive(true);
        SettingsDetails.SetActive(false);
    }

    public void Note_1()
    {
        ResetNotes();
        Notes[0].SetActive(true);
    }

    public void Note_2()
    {
        ResetNotes();
        Notes[1].SetActive(true);
    }

    public void Note_3()
    {
        ResetNotes();
        Notes[2].SetActive(true);
    }

    public void Note_4()
    {
        ResetNotes();
        Notes[3].SetActive(true);
    }

    public void Note_5()
    {
        ResetNotes();
        Notes[4].SetActive(true);
    }

    public void Note_6()
    {
        ResetNotes();
        Notes[5].SetActive(true);
    }

    public void Note_7()
    {
        ResetNotes();
        Notes[6].SetActive(true);
    }

    public void Note_8()
    {
        ResetNotes();
        Notes[7].SetActive(true);
    }
    public void Note_9()
    {
        ResetNotes();
        Notes[8].SetActive(true);
    }




    public void OpenSettings()
    {
        NoteTab.SetActive(true);
        NoteTabBig.SetActive(false);
        SettingsTabBig.SetActive(true);
        SettingsTab.SetActive(false);

        NoteDetails.SetActive(false);
        SettingsDetails.SetActive(true);
    }

    public void pageVisibility()
    {
        if(Page == 1)
        {
            if(EnablePage2 == true)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(false);
            }
            else
            {
                NextPage.SetActive(false);
                PrevPage.SetActive(false);
            }
        }
        else if(Page == 2)
        {
            if(EnablePage3)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 3)
        {
            if(EnablePage4)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 4)
        {
            if(EnablePage5)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 5)
        {
            if (EnablePage6)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 6)
        {
            if (EnablePage7)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 7)
        {
            if (EnablePage8)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 8)
        {
            if (EnablePage9)
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if(Page == 9)
        {
            NextPage.SetActive(false);
            PrevPage.SetActive(true);
        }
    }

    void displayNextButton()
    {
        NextPage.SetActive(false);
        PrevPage.SetActive(true);
    }

    public void GoNextPage()
    {
        if (Page == 1)
        {
            Note_2();
            Page++;
        }
        else if(Page == 2)
        {
            Note_3();
            Page++;
        }
        else if (Page == 3)
        {
            Note_4();
            Page++;
        }
        else if (Page == 4)
        {
            Note_5();
            Page++;
        }
        else if (Page == 5)
        {
            Note_6();
            Page++;
        }
        else if (Page == 6)
        {
            Note_7();
            Page++;
        }
        else if (Page == 7)
        {
            Note_8();
            Page++;
        }
        else if (Page == 8)
        {
            Note_9();
            Page++;
        }
        else if (Page == 9)
        {
            //Nothing
        }

    }

    public void GoPrevPage()
    {
        if (Page == 1)
        {
            //nothing
        }
        else if (Page == 2)
        {
            Note_1();
            Page--;
        }
        else if (Page == 3)
        {
            Note_2();
            Page--;
        }
        else if (Page == 4)
        {
            Note_3();
            Page--;
        }
        else if (Page == 5)
        {
            Note_4();
            Page--;
        }
        else if (Page == 6)
        {
            Note_5();
            Page--;
        }
        else if (Page == 7)
        {
            Note_6();
            Page--;
        }
        else if (Page == 8)
        {
            Note_7();
            Page--;
        }
        else if (Page == 9)
        {
            Note_8();
            Page--;
        }
    }

    private void ResetNotes()
    {
        for(int x = 0; x < 9; x++)
        {
            Notes[x].SetActive(false);
        }
    }
}
