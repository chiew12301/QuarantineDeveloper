using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Script : MonoBehaviour
{
    public int totalPuzzle = 0;
    public bool isPuzzleDone = false;

    public GameObject completeMoonStar;
    public GameObject incompleteMoonStar;
    public GameObject frameBefore;
    public GameObject frameAfter;

    public GameObject cabinetForPuzzle3;
    public GameObject cabinetForMusicBox;

    public GameObject mirrorBefore;
    public GameObject mirrorAfter;

    public GameObject[] JigsawPuzzle;

    private bool endPuzzlePicking = false;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            JigsawPuzzle[i].SetActive(false);
        }
    }

    private void Update()
    {
        PuzzleCompleted();
    }

    void PuzzleCompleted()
    {
        if (totalPuzzle >= 3)
        {
            incompleteMoonStar.SetActive(false);
            completeMoonStar.SetActive(true);

            frameBefore.SetActive(false);
            frameAfter.SetActive(true);

            mirrorBefore.SetActive(false);
            mirrorAfter.SetActive(true);

            cabinetForPuzzle3.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jigsaw"))
        {
            totalPuzzle++;
            //collision.gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void enableCabinetAfter()
    {
        cabinetForMusicBox.SetActive(true);
    }

    public void enablePuzzleItems()
    {
        if (!endPuzzlePicking)
        {
            for (int i = 0; i < 3; i++)
            {
                JigsawPuzzle[i].SetActive(true);
                endPuzzlePicking = true;
            }
        }
        
    }

}
