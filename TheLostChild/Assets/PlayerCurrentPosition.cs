using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentPosition : MonoBehaviour
{
    [Header("Rooms - 1st Floor")]
    public bool Hallway1 = false;
    public bool Lobby = false;
    public bool CeramicGallery = false;
    public bool ArtStation = false;
    public bool Antique_Photograph = false;

    [Header("Rooms - 2nd Floor")]
    public bool PontianakGallery = false;
    public bool Hallway2 = false;
    public bool HistoriacalTimeGallery = false;
    public bool StoreRoom = false;
    public bool OldPaintingGallery = false;
    public bool Toilet = false;

    [Header("Player Icon (Journal)")]
    public GameObject []playerIcon;
    public GameObject[] OverlayBG;

    [Header("Enemy Soldiers (Journal)")]
    public GameObject soldier;

    public static bool displayEnemyInjournal = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (Hallway1)                   // -- Floor 1 --
            {
                EnableOverlay();
                OverlayBG[0].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[0].SetActive(true);
            }
            else if (Lobby)
            {
                EnableOverlay();
                OverlayBG[1].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[1].SetActive(true);
            }
            else if (CeramicGallery)
            {
                EnableOverlay();
                OverlayBG[2].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[2].SetActive(true);
            }
            else if (ArtStation)
            {
                EnableOverlay();
                OverlayBG[3].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[3].SetActive(true);
            }
            else if (Antique_Photograph)
            {
                EnableOverlay();
                OverlayBG[4].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[4].SetActive(true);
            }
            else if (PontianakGallery)    // -- Floor 2 --
            {
                EnableOverlay();
                OverlayBG[5].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[5].SetActive(true);
            }
            else if (Hallway2)
            {
                EnableOverlay();
                OverlayBG[6].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[6].SetActive(true);
            }
            else if (HistoriacalTimeGallery)
            {
                EnableOverlay();
                OverlayBG[7].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[7].SetActive(true);
            }
            else if (StoreRoom)
            {
                EnableOverlay();
                OverlayBG[8].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[8].SetActive(true);
            }
            else if (OldPaintingGallery)
            {
                EnableOverlay();
                OverlayBG[9].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[9].SetActive(true);
            }
            else if (Toilet)
            {
                EnableOverlay();
                OverlayBG[10].SetActive(false);
                DisableAllPlayerIcon();
                playerIcon[10].SetActive(true);
            }

        }
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemySoldier_1"))
        {
            //displayEnemyInjournal = true;
        }

        if (collision.CompareTag("Player") && displayEnemyInjournal)
        {
            if (Hallway1 || Hallway2)
            {
                soldier.SetActive(true);
            }
        }
    }

    void DisableAllPlayerIcon()
    {
        for(int x = 0; x < 11; x++)
        {
            playerIcon[x].SetActive(false);
        }
    }

    void EnableOverlay()
    {
        for (int x = 0; x < 11; x++)
        {
            OverlayBG[x].SetActive(true);
        }
    }
}

//playerIcon.transform.position = new Vector3(-152.5f, 117.4f);