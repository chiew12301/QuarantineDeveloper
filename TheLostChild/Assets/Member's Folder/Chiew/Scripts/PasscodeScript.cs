using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasscodeScript : MonoBehaviour
{
    public SafeVaultTrigger svTrigger;
    public string insertNum;
    public string thePassCode = "2121";
    public TextMeshProUGUI passcodeText;
    public Dialogue Puzzle2Ending;
    public GameObject photoItem;
    private bool isCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        svTrigger.SVUIOff();
        insertNum = "0000";
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
        }

        if (insertNum.Length >= 4 && isCompleted == false)
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
