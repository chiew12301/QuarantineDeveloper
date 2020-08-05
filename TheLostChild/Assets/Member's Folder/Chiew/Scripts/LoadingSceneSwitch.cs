using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneSwitch : MonoBehaviour
{
    [Header("Next Scene")]
    public string _NxtScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(switchNxt());
    }

    IEnumerator switchNxt()
    {

        yield return new WaitForSeconds(5f);
        if (_NxtScene != null)
        {
            SceneManager.LoadScene(_NxtScene);
        }

        yield return null;
    }

}
