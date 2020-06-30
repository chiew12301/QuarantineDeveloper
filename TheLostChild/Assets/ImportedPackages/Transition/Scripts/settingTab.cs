using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingTab : MonoBehaviour
{
    public AudioMixer audio;
    public void setVolume(float volume)
    {
        audio.SetFloat("masterVolume",volume);
    }
}
