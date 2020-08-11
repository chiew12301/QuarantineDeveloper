using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJournalNoteAuto : MonoBehaviour
{
    public int PageNumberToGet = 0;
    public static bool getNote2 = true;
    public static bool getNote5 = false;
    public static bool getNote11 = false;

    public bool note2 = false;
    public bool note5 = false;
    public bool note11 = false;

    private void Start()
    {
        getNote2 = true;
        getNote5 = false;
        getNote11 = false;
    }

    void Update()
    {

        if (getNote2 == true && note2)
        {
            getPage2();
            getNote2 = false;
        }

        if (getNote5 && note5)
        {
            getPage5();
            getNote5 = false;
        }

        if(getNote11 && note11)
        {
            getPage11();
            getNote11 = false;
        }
    }

    void getPage2()
    {
        UnlockJournalPage.instance.PageNumber = PageNumberToGet;
        UnlockJournalPage.instance.performPickup();
    }

    void getPage5()
    {
        UnlockJournalPage.instance.PageNumber = PageNumberToGet;
        UnlockJournalPage.instance.performPickup();
        PlayerCurrentPosition.displayEnemyInjournal = true;
    }

    void getPage11()
    {
        UnlockJournalPage.instance.PageNumber = PageNumberToGet;
        UnlockJournalPage.instance.performPickup();
    }
}
