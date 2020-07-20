using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void returnToMM()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goodEnding()
    {
        //Dialogue related code
        PlayerPrefs.SetInt("Ending", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");


    }

    public void badEnding()
    {
        //Dialogue related Code
        PlayerPrefs.SetInt("Ending", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");

    }

}
