using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Script : MonoBehaviour
{
    public static Puzzle1Script instance;

    Collider2D col;

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
            col = GetComponent<Collider2D>();
        }
    }

    private void Update()
    {
        PuzzleCompleted();
    }

    private void Awake()
    {
        instance = this;
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

            col.enabled = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jigsaw") || collision.CompareTag("Jigsaw2") || collision.CompareTag("Jigsaw3"))
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
