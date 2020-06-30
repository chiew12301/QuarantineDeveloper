using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScriptUI : MonoBehaviour
{
    public static InventoryScriptUI instance;

    private Inventory inventory;
    private MoveScriptTesting playerScript;
    private SlotsScript[] itemSlots;
    public Transform itemParent;
    public GameObject slotPrefab;
    public bool isOpen = false;
    public GameObject GranParentsInventory;
    public GameObject CloseInventoryButton;
    public GameObject OpenInventoryImage;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        closeInventorySlots();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MoveScriptTesting>();
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
    }

    public void UpdateUI()
    {
        itemSlots = itemParent.GetComponentsInChildren<SlotsScript>();

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < inventory.itemLists.Count)
            {
                itemSlots[i].AddItem(inventory.itemLists[i]);
            }
            else
            {
                itemSlots[i].ClearIcon();
            }
        }
    }

    private void Update()
    {

    }
    public void closeInventorySlots()
    {
        OpenInventoryImage.gameObject.SetActive(true);
        GranParentsInventory.gameObject.SetActive(false);
        CloseInventoryButton.gameObject.SetActive(false);
        isOpen = false;
    }

    public void openInventorySlots()
    {
        playerScript.StopMoving();
        OpenInventoryImage.gameObject.SetActive(false);
        GranParentsInventory.gameObject.SetActive(true);
        CloseInventoryButton.gameObject.SetActive(true);
        isOpen = true;
    }
}
 