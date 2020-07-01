using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoSceneScript : MonoBehaviour
{
    public float waitTime = 5f;
    void Start()
    {
        StartCoroutine(DelaySwitch());
    }

    IEnumerator DelaySwitch()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("MainMenu");
    }

}
