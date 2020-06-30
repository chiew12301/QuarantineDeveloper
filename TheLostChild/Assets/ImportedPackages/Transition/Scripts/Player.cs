using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Vector3 loadPosition;
    private bool loadedYet = true;
    //private savePointTouch bench;
    //public string savePointName;

    void Start()
    {
        //GameObject savePoint = GameObject.FindGameObjectWithTag(" ");
        //bench = savePoint.GetComponent<savePointTouch>();

    }

    void Update()
    {
        //if (loadedYet)
        //{
        //    Debug.Log(loadedYet);
        //}
        if (loadedYet == false && transform.position.x != loadPosition.x)
        {
            transform.position = new Vector3(loadPosition.x, loadPosition.y);
            //Debug.Log("something happens");
            //loadedYet = true;
        }
    }

    public void savePlayer()
    {
        saveSystem.Save(this);       
    }

    public void loadPlayer()
    {
        loadedYet = false;
        playerData data = saveSystem.Load();
        loadPosition.x = data.position[0];
        loadPosition.y = data.position[1];
        //Debug.Log(loadedYet);
        SceneManager.LoadScene("MasterScene");
        //Debug.Log(loadedYet);
    }
}
