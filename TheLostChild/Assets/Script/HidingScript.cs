using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingScript : MonoBehaviour
{
    [SerializeField]
    Transform p;

    public GameObject player;
    public float rangeToInteract = 1; 


    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, p.position);

        if(distToPlayer < rangeToInteract)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Wall"))
                    {
                        if (player.activeInHierarchy == false)
                        {
                            player.SetActive(true);
                            //player.transform.position = transform.position;
                        }
                        else if (player.activeInHierarchy == true)
                        {
                            player.SetActive(false);
                        }
                    }
                }

            }
        }


        
    }
}
