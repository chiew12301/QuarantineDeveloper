using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomCabinetP1 : MonoBehaviour
{
    public GameObject mirror;
    public GameObject MusicBox;
    // Update is called once per frame
    void Update()
    {
        checkGiveMusicBox();
    }

    void checkGiveMusicBox()
    {
        if(mirror.GetComponent<PickUp>().isRiddleDone == true)
        {
            MusicBox.GetComponent<MusicBoxSwitchSceneScript>().performPickup();
        }
    }

}
