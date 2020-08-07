using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JournalScript : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;

    public GameObject NoteNotifyPanel;
    public GameObject MapNotifyPanel;

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
    public static bool EnablePage10 = false;
    public static bool EnablePage11 = false;
    public static bool EnablePage12 = false;




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

    [Header("Map Tabs")]    //Journal Tabs
    public GameObject MapDetails;
    public GameObject MapTab;
    public GameObject MapTabBig;
    public Button MapTabSmall;

    MoveScriptTesting player;

    private const int SIZE = 12;
    public static int p = -1;
    public static int[] currentPage = new int[SIZE];
    public static bool[] enableArrows = new bool[SIZE];
    

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<MoveScriptTesting>();

        for(int x = 0; x < 12; x++)
        {
            enableArrows[x] = false;
        }
    }

    void Update()
    {
        pageVisibility();

    }
    

    public void Note_1()
    {
        ResetNotes();
        Notes[0].SetActive(true);
    }




    public void pageVisibility()
    {
        if(Page == 1)
        {
            if(enableArrows[0] == true)
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
            if(enableArrows[1])
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
            if(enableArrows[2])
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
            if(enableArrows[3])
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
            if (enableArrows[4])
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
            if (enableArrows[5])
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
            if (enableArrows[6])
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
            if (enableArrows[7])
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 9)
        {
            if (enableArrows[8])
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 10)
        {
            if (enableArrows[9])
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if (Page == 11)
        {
            if (enableArrows[10])
            {
                NextPage.SetActive(true);
                PrevPage.SetActive(true);
            }
            else
            {
                displayNextButton();
            }
        }
        else if(Page == 12)
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
            ResetNotes();
            Notes[currentPage[0]].SetActive(true);
            Page++;
        }
        else if(Page == 2)
        {
            ResetNotes();
            Notes[currentPage[1]].SetActive(true);
            Page++;
        }
        else if (Page == 3)
        {
            ResetNotes();
            Notes[currentPage[2]].SetActive(true);
            Page++;
        }
        else if (Page == 4)
        {
            ResetNotes();
            Notes[currentPage[3]].SetActive(true);
            Page++;
        }
        else if (Page == 5)
        {
            ResetNotes();
            Notes[currentPage[4]].SetActive(true);
            Page++;
        }
        else if (Page == 6)
        {
            ResetNotes();
            Notes[currentPage[5]].SetActive(true);
            Page++;
        }
        else if (Page == 7)
        {
            ResetNotes();
            Notes[currentPage[6]].SetActive(true);
            Page++;
        }
        else if (Page == 8)
        {
            ResetNotes();
            Notes[currentPage[7]].SetActive(true);
            Page++;
        }
        else if (Page == 9)
        {
            ResetNotes();
            Notes[currentPage[8]].SetActive(true);
            Page++;
        }
        else if (Page == 10)
        {
            ResetNotes();
            Notes[currentPage[9]].SetActive(true);
            Page++;
        }
        else if (Page == 11)
        {
            ResetNotes();
            Notes[currentPage[10]].SetActive(true);
            Page++;
        }
        else if (Page == 12)
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
            ResetNotes();
            Notes[currentPage[0]].SetActive(true);
            Page--;
        }
        else if (Page == 4)
        {
            ResetNotes();
            Notes[currentPage[1]].SetActive(true);
            Page--;
        }
        else if (Page == 5)
        {
            ResetNotes();
            Notes[currentPage[2]].SetActive(true);
            Page--;
        }
        else if (Page == 6)
        {
            ResetNotes();
            Notes[currentPage[3]].SetActive(true);
            Page--;
        }
        else if (Page == 7)
        {
            ResetNotes();
            Notes[currentPage[4]].SetActive(true);
            Page--;
        }
        else if (Page == 8)
        {
            ResetNotes();
            Notes[currentPage[5]].SetActive(true);
            Page--;
        }
        else if (Page == 9)
        {
            ResetNotes();
            Notes[currentPage[6]].SetActive(true);
            Page--;
        }
        else if (Page == 10)
        {
            ResetNotes();
            Notes[currentPage[7]].SetActive(true);
            Page--;
        }
        else if (Page == 11)
        {
            ResetNotes();
            Notes[currentPage[8]].SetActive(true);
            Page--;
        }
        else if (Page == 12)
        {
            ResetNotes();
            Notes[currentPage[9]].SetActive(true);
            Page--;
        }
    }









    public void ExitJournal()
    {
        TutorialScript.gameStart = true;
        //TutorialScript.disableTutorialBlocks = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        ResetNotes();
        JournalButton.interactable = true;
    }

    
    public void OpenJournal()
    {
        NoteNotifyPanel.SetActive(false);
        MapNotifyPanel.SetActive(false);
        OpenNoteTab();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0001f;
        player.StopMoving();
        GameisPaused = true;

        Notes[0].SetActive(true);
        Notes[1].SetActive(false);

        JournalButton.interactable = false;

        Page = 1;
    }

    public void OpenNoteTab()
    {
        NoteTab.SetActive(false);
        NoteTabBig.SetActive(true);
        SettingsTab.SetActive(true);
        SettingsTabBig.SetActive(false);

        if(SetMapJournal.MapIsAvailable == true)
        {
            MapTab.SetActive(true);
            MapTabBig.SetActive(false);
        }        
        
        NoteDetails.SetActive(true);
        SettingsDetails.SetActive(false);
        MapDetails.SetActive(false);
    }

    public void OpenSettings()
    {
        NoteTab.SetActive(true);
        NoteTabBig.SetActive(false);
        SettingsTab.SetActive(false);
        SettingsTabBig.SetActive(true);

        if (SetMapJournal.MapIsAvailable == true)
        {
            MapTab.SetActive(true);
            MapTabBig.SetActive(false);
        }

        NoteDetails.SetActive(false);
        SettingsDetails.SetActive(true);
        MapDetails.SetActive(false);
    }

    public void OpenMap()
    {
        NoteTab.SetActive(true);
        NoteTabBig.SetActive(false);
        SettingsTab.SetActive(true);
        SettingsTabBig.SetActive(false);

            MapTab.SetActive(false);
            MapTabBig.SetActive(true);
        
            
        NoteDetails.SetActive(false);
        SettingsDetails.SetActive(false);
        MapDetails.SetActive(true);
    }


    private void ResetNotes()
    {
        for(int x = 0; x < 12; x++)
        {
            Notes[x].SetActive(false);
        }
    }
}
