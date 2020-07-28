using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class newGame : MonoBehaviour
{
    public string firstScene;
    public Animator transition;
    private float transitionTime = 2f;
    public TextMeshProUGUI textLoading;
    // Start is called before the first frame update


    private void Start()
    {
        textLoading.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void newStart()
    {
        //textLoading.gameObject.SetActive(true);
        //SceneManager.LoadScene(firstScene);
        //StartCoroutine(LoadLevel());
        SceneManager.LoadScene("Loading Scene");
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Game Scene");
        textLoading.gameObject.SetActive(false);
    }
}
