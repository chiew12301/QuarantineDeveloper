using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsScript : MonoBehaviour
{
    public static SlotsScript instance;
    public int i;
    public Image Icon;
    public Item item;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        Icon.sprite = item.itemSprite;
        Icon.enabled = true;
    }
    public void ClearIcon()
    {
        item = null;

        Icon.sprite = null;
        Icon.enabled = false;
    }

    public void RemoveItem()
    {
        if (item != null)
        {
            Inventory.instance.ClearItem(item);
        }
    }

    public void DropItem()
    {
        if (item != null)
        {
            item.Drop();
            CreateOnMouse(item.itemPrefab);
            Inventory.instance.ClearItem(item);
        }
    }

    public void CreateOnMouse(GameObject i)
    {
        ObjectPoolingManager.instance.FindObjectinPool(i);
    }

}
