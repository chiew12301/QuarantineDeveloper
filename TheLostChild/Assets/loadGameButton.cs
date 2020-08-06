using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



public class loadGameButton : MonoBehaviour
{
    public Text load = null;


    // Update is called once per frame
    void Update()
    {
        string path = Application.persistentDataPath + "/player.Data";
        if (!File.Exists(path))
        {
            this.GetComponent<Button>().interactable = false;
            if (load != null)
            {
                this.GetComponent<Image>().enabled = false;
                load.color = Color.grey;
            }
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
            if (load != null)
            {
                this.GetComponent<Image>().enabled = true;
                load.color = Color.black;
            }
        }
    }
}
