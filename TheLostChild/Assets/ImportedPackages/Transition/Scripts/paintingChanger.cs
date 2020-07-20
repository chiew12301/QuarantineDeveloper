using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paintingChanger : MonoBehaviour
{
    Image currentImage;
    public Sprite newGame;
    public Sprite goodEnding;
    public Sprite badEnding;
    public Sprite secretEnding;

    void Start()
    {
        currentImage = GetComponent<Image>();    
    }

    void Update()
    {

        if (PlayerPrefs.GetInt("Ending") == 0)
        {
            currentImage.sprite = newGame;
        }
        if (PlayerPrefs.GetInt("Ending") == 1)
        {
            currentImage.sprite = goodEnding;
        }
        if (PlayerPrefs.GetInt("Ending") == 2)
        {
            currentImage.sprite = badEnding;
        }

    }
}
