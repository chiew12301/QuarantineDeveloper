using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public DialogueCutscene DCS;

    //public GameObject Enemy1Parents;
    //public GameObject Enemy1;

    public bool isChangedOnce = false;

    void Start()
    {
        //player = GameObject.Find("Player").transform;
        //DCS = GameObject.Find("StartDialogueManager").GetComponent<DialogueCutscene>();
    }

    void Update()
    {//1.836094
        transform.position = new Vector3(player.position.x, player.position.y + 2f, player.position.z - 142.9511f);
        //CheckisPlayedCS3();
    }

    //public void activeEnemy()
    //{
    //    if (DCS.isCutS3PlayedP1 == true)
    //    {
    //        Enemy1Parents.SetActive(true);
    //    }
    //}

    //public void CheckisPlayedCS3()
    //{
    //    if(DCS.isCutS3PlayedP1 == true && DCS.isCutS3PlayedP2 == true && DCS.isExitLobby == true )
    //    {
    //        //transform.position = new Vector3(Enemy1.transform.position.x, Enemy1.transform.position.y + 2f, player.position.z - 142.9511f);
    //    }
    //}

    //public void TransportToPainting()
    //{
    //    if (DCS.isCutSLIG == true)
    //    {
    //        player.position = new Vector3(-10.6f, 126.8f, 0);
    //    }
    //}
}
