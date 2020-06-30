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
}
