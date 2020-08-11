using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSceneScript : MonoBehaviour
{
    public float waitTime = 5f;
    public string sceneName = "MainMenu";
    void Start()
    {
        StartCoroutine(DelaySwitch());
    }

    IEnumerator DelaySwitch()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneName);
    }

}
