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

    [Header("Player Icon (Journal)")]
    public GameObject []playerIcon;

    [Header("Enemy Soldiers (Journal)")]
    public GameObject soldier;

    bool displayEnemyInjournal = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (Hallway1)                   // -- Floor 1 --
            {
                DisableAllPlayerIcon();
                playerIcon[0].SetActive(true);
            }
            else if (Lobby)
            {
                DisableAllPlayerIcon();
                playerIcon[1].SetActive(true);
            }
            else if (CeramicGallery)
            {
                DisableAllPlayerIcon();
                playerIcon[2].SetActive(true);
            }
            else if (ArtStation)
            {
                DisableAllPlayerIcon();
                playerIcon[3].SetActive(true);
            }
            else if (Antique_Photograph)
            {
                DisableAllPlayerIcon();
                playerIcon[4].SetActive(true);
            }
            else if (PontianakGallery)    // -- Floor 2 --
            {
                DisableAllPlayerIcon();
                playerIcon[5].SetActive(true);
            }
            else if (Hallway2)
            {
                DisableAllPlayerIcon();
                playerIcon[6].SetActive(true);
            }
            else if (HistoriacalTimeGallery)
            {
                DisableAllPlayerIcon();
                playerIcon[7].SetActive(true);
            }
            else if (StoreRoom)
            {
                DisableAllPlayerIcon();
                playerIcon[8].SetActive(true);
            }
            else if (OldPaintingGallery)
            {
                DisableAllPlayerIcon();
                playerIcon[9].SetActive(true);
            }

        }
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemySoldier_1"))
        {
            displayEnemyInjournal = true;    
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
        for(int x = 0; x < 10; x++)
        {
            playerIcon[x].SetActive(false);
        }
    }
}

//playerIcon.transform.position = new Vector3(-152.5f, 117.4f);