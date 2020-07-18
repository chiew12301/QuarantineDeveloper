using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VetScript : MonoBehaviour
{
    [HideInInspector]
    public bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        isCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollected();
    }

    void CheckCollected()
    {
        if(isCollected == true)
        {
            //give journal for password
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NegativeFilm"))
        {
            collision.gameObject.SetActive(false);
            isCollected = true;
        }
        else
        {
            return;
        }
    }

}
