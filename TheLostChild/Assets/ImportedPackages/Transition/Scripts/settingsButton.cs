using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsButton : MonoBehaviour
{
    public void changeToSettings()
    {
        SceneManager.LoadScene("Settings Scene");
    }
    
}
