using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject SettingsMenuUI;

    public GameObject ConfirmationMessage;

    public void Pause()
    {
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameisPaused = false;

    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        //Debug.Log("Returning to Main Menu");
        ConfirmationMessage.SetActive(true);
        SettingsMenuUI.SetActive(false);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NoButton()
    {
        ConfirmationMessage.SetActive(false);
    }


    public void Volume()
    {
        SettingsMenuUI.SetActive(true);
        ConfirmationMessage.SetActive(false);
    }

    public void ExitSettings()
    {
        SettingsMenuUI.SetActive(false);
        ConfirmationMessage.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
