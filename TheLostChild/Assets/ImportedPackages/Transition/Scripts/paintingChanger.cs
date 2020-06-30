using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global
{
    public static int state = 0;
    //0 = New Game
    //1 = Happy ending
    //2 = Bad Ending
    //3 = Secret ending
}
public class paintingChanger : MonoBehaviour
{
    public int curState = 0;
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

        if (curState == 0)
        {
            currentImage.sprite = newGame;
        }
        if (curState == 1)
        {
            currentImage.sprite = goodEnding;
        }
        if (curState == 2)
        {
            currentImage.sprite = badEnding;
        }
        if (curState == 3)
        {
            currentImage.sprite = secretEnding;
        }
        //if (Global.state == 0)
        //{
        //    currentImage.sprite = newGame;
        //}
        //if(Global.state == 1)
        //{
        //    currentImage.sprite = goodEnding;
        //}
        //if (Global.state == 2)
        //{
        //    currentImage.sprite = badEnding;
        //}
        //if (Global.state == 3)
        //{
        //    currentImage.sprite = secretEnding;
        //}
    }
}
