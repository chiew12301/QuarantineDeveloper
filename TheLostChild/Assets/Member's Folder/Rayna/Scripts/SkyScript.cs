using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class SkyScript : MonoBehaviour
{
    public GameObject player;

    bool isMove = false;
    // Update is called once per frame
    void Update()
    {
        checkPlayerReach();
    }

    void checkPlayerReach()
    {
        if(player.transform.position.x >= this.transform.position.x)
        {
            isMove = true;
        }
        if(player.transform.position.x < 17.45f)
        {
            isMove = true;
        }

        if(this.transform.position.x >= 17.45f && player.transform.position.x >= 17.45f)
        {
            isMove = false;
        }

        if(isMove == true)
        {
            Vector3 temp;
            temp.x = player.transform.position.x;
            temp.y = this.transform.position.y;
            temp.z = this.transform.position.z;

            this.transform.position = temp;
        }
    }

}
