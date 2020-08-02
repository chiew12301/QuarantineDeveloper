using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBottle : MonoBehaviour
{
   void OnMouseDown()
    {
        OpenPanel.instance.hasPickedUpBottle = true;
    }
}
