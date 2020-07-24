using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasscodeScript : MonoBehaviour
{
    public MoveScriptTesting player;
    public Vector3 backtoGallery;
    public SafeVaultTrigger svTrigger;
    public string insertNum;
    public string thePassCode = "08121941";
    public TextMeshProUGUI passcodeText;
    public Dialogue Puzzle2Ending;
    public GameObject photoItem;
    private bool isCompleted = false;
    public GameObject inventoryPanel;
    // Start is called before the first frame update
    void Start()
    {
        svTrigger.SVUIOff();
        insertNum = "00000000";
        inventoryPanel.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        checkNumber();
    }

    public void checkNumber()
    {
        if(insertNum == thePassCode)
        {
            svTrigger.SVUIOff();
            Debug.Log("Win");
            isCompleted = true;
            DialogueManager.instance.StartDialogue(Puzzle2Ending);
            if(photoItem.GetComponent<PickUp>() != null)
            {
                photoItem.GetComponent<PickUp>().performPickup();
            }
            //Transfer to puzzle gallery again
            this.GetComponent<TransferPlayer>().TransferPlayerToDes();
            inventoryPanel.gameObject.SetActive(true);
            //player.gameObject.transform.position = backtoGallery;
        }

        if (insertNum.Length >= 8 && isCompleted == false)
        {
            insertNum = "";
        }
        passcodeText.text = insertNum;
    }

    public void updateInsertNum(string num)
    {
        insertNum += num;
    }

}
