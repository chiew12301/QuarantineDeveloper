using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    //Reference to Audio Source component
    private AudioManager audioSrc;

    // Music volume variable that will be modified by dragging slider knob
    private float musicVolume = 0.5f;

    void Start()
    {
        audioSrc = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        //audioSrc.AdjustVolume("BGM",musicVolume);
        AudioManager.instance.AdjustAllVolume(musicVolume);
    }

    // Method that is called by slider game object
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
