using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomHitboxButton : MonoBehaviour
{
    void Start()
    {
        if (this.GetComponent<Image>() != null)
        {
            this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.9f;
        }
    }
}
