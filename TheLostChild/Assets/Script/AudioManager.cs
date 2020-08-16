using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //Store Every Sounds, Refer Inspector

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) //For Multiple Scene Purpose
        {
            instance = this;
        }           
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        AdjustAllVolume(0.5f);
        Play("MainMenuBGM"); //Play BGM
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            if(FindIsPlaying("MainMenuBGM") == false)
            {
                Play("MainMenuBGM");
                Stop("BGM");
                Stop("Credit");
            }
        }
        else if (sceneName == "Game Scene")
        {
            Stop("MainMenuBGM");
            Stop("Credit");

            //if no default bg is played
            if (FindIsPlaying("BGM") == false)
            {
                if(FindIsPlaying("SealRoom1") == true || FindIsPlaying("MusicBox") == true || FindIsPlaying("SealRoom2") == true || FindIsPlaying("SealRoom3") == true || FindIsPlaying("SealRoom4") == true )
                {
                    return;
                }
                //if none of the seal rooms bg are being played/ music box
                else//if(FindIsPlaying("SealRoom1") == false || FindIsPlaying("MusicBox") == false)
                {
                    Play("BGM");
                }
            }
        }
        else if (sceneName == "StayTuneScene")
        {
            if (FindIsPlaying("Credit") == false)
            {
                Play("Credit");
                Stop("MainMenuBGM");
                Stop("BGM");
            }
        }
    }

    public bool FindIsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) //Warning Debug
        {
            Debug.LogWarning("Sounds: " + name + " not found!");
            return false;
        }
        return s.source.isPlaying;
    }

    public void Play(string name) //Play Sound source
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) //Warning Debug
        {
            Debug.LogWarning("Sounds: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name) //Pause Sound source
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) //Warning Debug
        {
            Debug.LogWarning("Sounds: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public void Stop(string name) //Stop Sound source
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) //Warning Debug
        {
            Debug.LogWarning("Sounds: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void AdjustVolume(string name, float amount)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) //Warning Debug
        {
            Debug.LogWarning("Sounds: " + name + " not found!");
            return;
        }
        if (amount >= 1)
        {
            amount = 1;
        }
        s.volume = amount;
        s.source.volume = s.volume;
    }

    public void AdjustAllVolume(float amount)
    {
        foreach(Sound s in sounds)
        {
            if (amount >= 1)
            {
                amount = 1;
            }
            else if(amount <= 0)
            {
                amount = 0;
            }
            s.volume = amount;
            s.source.volume = s.volume;
        }
    }

}
