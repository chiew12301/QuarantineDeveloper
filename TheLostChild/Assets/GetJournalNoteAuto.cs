using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJournalNoteAuto : MonoBehaviour
{
    public int PageNumberToGet = 0;
    public static bool getNote2 = true;
    public static bool getNote5 = false;

    public bool note2 = false;
    public bool note5 = false;


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
    }
}
