using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite itemSprite = null; //Item Sprite/Icon
    new public string name = "New Item"; //Name of the item
    new public string desc = "New Desc"; //Description of the item
    public ItemType itemType; //Extra Element for future
    public GameObject itemPrefab;
    public bool isFull = false; //Testing purpose

    public enum ItemType
    {
        Book,
        Diamond,
        Lighter,
        Flyer,
        Hairpin,
        Musicbox,
        Jigsaw,
    }

    public Item(string na, string des) //Default constructor
    {
        name = na;
        desc = des;
    }

    public virtual void UseItem() //Debug Name
    {
        //Debug.Log("Using " + name);
    }

    public virtual void Drop()
    {
        //Debug.Log("Drop");
    }

}
