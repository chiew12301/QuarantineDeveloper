using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public static bool hidden = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position = transform.position + new Vector3(1.0f, 0.0f, 0.0f);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (!hidden)
        {
            gameObject.tag = "Player";
            hidden = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            gameObject.tag = "Hidden";
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Wall"))
        {
            gameObject.tag = "Player";
        }

        
    }
}
