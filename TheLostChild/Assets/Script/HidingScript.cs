using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HidingScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Transform p;

    public GameObject player;
    public float rangeToInteract = 5;
    private MouseCursor mcs;

    private void Start()
    {
        mcs = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseCursor>();
    }

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
                            AudioManager.instance.Stop("HeartBeat");
                            //player.transform.position = transform.position;

                            MoveScriptTesting.instance.Move();
                        }
                        else if (player.activeInHierarchy == true)
                        {
                            player.SetActive(false);
                            AudioManager.instance.Play("HeartBeat");
                            MoveScriptTesting.instance.StopMoving();
                        }
                    }
                }

            }
        }

    }

    public void OnPointerEnter(PointerEventData data)
    {
        mcs.setToCursorEyes("Hover");
    }

    public void OnPointerExit(PointerEventData data)
    {
        mcs.setToDefaultCursor("Hover");
    }
}
