using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCollector : MonoBehaviour
{
    [Header("Game Object")]
    public GameObject ItemCollect;
    public GameObject BarrierToUnlock;
    public GameObject Children;

    public Sprite childrenSprite;

    private bool isCollected = false;

    private Renderer r;
    private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        childrenSprite = this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        newColor = Children.GetComponent<SpriteRenderer>().material.color;
        newColor.a = 0;
        Children.GetComponent<SpriteRenderer>().material.color = newColor;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIscollected();
    }

    void CheckIscollected()
    {
        if(isCollected == true)
        {
            childrenSprite = ItemCollect.GetComponent<SpriteRenderer>().sprite;
            //this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite = childrenSprite;
            Children.GetComponent<SpriteRenderer>().sprite = childrenSprite;
            newColor = Children.GetComponent<SpriteRenderer>().material.color;
            newColor.a = 1;
            Children.GetComponent<SpriteRenderer>().material.color = newColor;
            BarrierToUnlock.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ItemCollect)
        {
            isCollected = true;
            collision.gameObject.SetActive(false);
        }
    }

}
