using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTeleporter : MonoBehaviour
{
    public GameObject[] Teleporter;

    private void OnEnable()
    {
        foreach(GameObject tp in Teleporter)
        {
            tp.gameObject.SetActive(false);
        }
    }
}
