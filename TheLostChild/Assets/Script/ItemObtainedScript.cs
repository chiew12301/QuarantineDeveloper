using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObtainedScript : MonoBehaviour
{
    public static ItemObtainedScript instance;

    public Text itemName;
    public Text itemDesc;
    public Image itemImage;

    private string tempItemName;
    private string tempItemDesc;
    private Sprite tempItemSprite;

    public GameObject Panel;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        tempItemName = Inventory.savedName;
        itemName.text = tempItemName;

        tempItemDesc = Inventory.savedDesc;
        itemDesc.text = tempItemDesc;

        tempItemSprite = Inventory.saveditemSprite;
        itemImage.sprite = tempItemSprite;
    }
    public void ClosePanel()
    {
        Time.timeScale = 1;
        Panel.SetActive(false);

    }
}
