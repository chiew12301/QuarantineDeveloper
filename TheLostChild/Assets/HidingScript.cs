//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HidingScript : MonoBehaviour
//{
//    //[Header("Bool")]
//    //bool isHide = false;
//    //bool MouseisIn = false;

//    //[Header("Player")]
//    //public MoveScriptTesting player;

//    //private MouseCursor mcS;
//    //private float Distance;

//    //private void Start()
//    //{
//    //    this.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
//    //    this.GetComponent<SpriteRenderer>().sortingOrder = 4;
//    //    player = GameObject.Find("Player").GetComponent<MoveScriptTesting>();
//    //    player.tag = "Player";
//    //}

//    //private void Update()
//    //{
//    //    if (Input.GetKeyDown(0))
//    //    {
//    //        if (calDistance(player.gameObject) <= 3 && MouseisIn == true)
//    //        {
//    //            onClick();
//    //            checkHide();
//    //        }
//    //    }
//    //}

//    //public void onClick()
//    //{
//    //    isHide = !isHide;
//    //}

//    //public void checkHide()
//    //{
//    //    if (isHide == true)
//    //    {
//    //        player.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, player.transform.position.z);
//    //        this.GetComponent<SpriteRenderer>().sortingOrder = 6;
//    //        player.tag = "Hidden";
//    //    }
//    //    else
//    //    {
//    //        player.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, player.transform.position.z);
//    //        this.GetComponent<SpriteRenderer>().sortingOrder = 4;
//    //        player.tag = "Player";
//    //    }
//    //}

//    //public float calDistance(GameObject playerObject)
//    //{
//    //    Distance = Vector2.Distance(this.gameObject.transform.position, playerObject.transform.position);
//    //    return Distance;
//    //}
//}
