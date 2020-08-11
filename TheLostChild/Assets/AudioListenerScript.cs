using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerScript : MonoBehaviour
{
    public AudioListener OwnAL;
    public AudioListener PlayAL;

    // Start is called before the first frame update
    void Start()
    {
        OwnAL.enabled = false;
        PlayAL.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkAL();
    }

    void checkAL()
    {
        if(PlayAL.enabled == true)
        {
            OwnAL.enabled = false;
        }
        if(PlayAL.gameObject.activeSelf == false)
        {
            OwnAL.enabled = true;
            PlayAL.enabled = false;
            return;
        }
        if(PlayAL.gameObject.activeSelf == true)
        {
            OwnAL.enabled = false;
            PlayAL.enabled = true;
            return;
        }
    }

}
