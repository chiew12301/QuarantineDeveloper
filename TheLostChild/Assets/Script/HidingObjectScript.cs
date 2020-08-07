using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObjectScript : MonoBehaviour
{
    public static HidingObjectScript instance;

    public GameObject[] hidingObject;
    public GameObject[] hidingBubbleTrigger;

    public bool isAbleHide = false;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsableHide();
    }

    void CheckIsableHide()
    {
        if(isAbleHide == true)
        {
            foreach(GameObject obj in hidingObject)
            {
                obj.gameObject.SetActive(true);
            }
            foreach(GameObject bubble in hidingBubbleTrigger)
            {
                bubble.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in hidingObject)
            {
                obj.gameObject.SetActive(false);
            }
            foreach (GameObject bubble in hidingBubbleTrigger)
            {
                bubble.gameObject.SetActive(true);
            }
        }
    }

}
