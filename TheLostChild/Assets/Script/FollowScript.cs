using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject parents;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = parents.transform.position;
    }
}
