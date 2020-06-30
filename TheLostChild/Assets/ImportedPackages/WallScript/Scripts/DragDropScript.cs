//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class DragDropScript : MonoBehaviour
//{
//    public bool selected;
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (selected == true)
//        {
//            moveObject();
//        }
//        if (Input.GetMouseButtonUp(0))
//        {
//            selected = false;
//        }
//    }

//    public void moveObject()
//    {
//        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        transform.position = new Vector3(mousePos.x, mousePos.y);
//    }

//    private void OnMouseOver()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            selected = true;
//        }
//    }
//}
