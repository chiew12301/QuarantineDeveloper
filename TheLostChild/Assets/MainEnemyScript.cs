using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemyScript : MonoBehaviour
{
    public GameObject EnemySoldier_1;
    public GameObject EnemySoldier_2;
    public static bool enableES = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableES)
        {
            EnemySoldier_1.SetActive(true);
            EnemySoldier_2.SetActive(true);
            HidingObjectScript.instance.isAbleHide = true;
        }
        else
        {
            EnemySoldier_1.SetActive(false);
            EnemySoldier_2.SetActive(false);
            HidingObjectScript.instance.isAbleHide = false;
        }
    }
}
