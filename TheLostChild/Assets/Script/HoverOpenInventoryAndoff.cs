using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOpenInventoryAndoff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MoveScriptTesting playerScript;
    public InventoryScriptUI inventoryScript;
    public DragDropScript[] ddS;
    public DetectorSlotScript[] ddsParents;
    private const int SIZE_ARRAY = 5;
    private bool[] CheckIsDone;
    public bool hovered = false;


    // Start is called before the first frame update
    void Start()
    {
        CheckIsDone = new bool[SIZE_ARRAY];
    }

    private void FixedUpdate()
    {
        Dostuff();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData data)
    {
        hovered = false;
    }

    void Dostuff()
    {
        if(hovered == true)
        {
            inventoryScript.openInventorySlots();
        }
        else if(hovered == false)
        {
            int counter = 0;
            for (int i = 0; i < SIZE_ARRAY; i++)
            {
                if (ddS[i].isHolding == false)
                {
                    for(int j = 0; j < SIZE_ARRAY; j++)
                    {
                        if (ddsParents[i].isHovered == false)
                        {
                            CheckIsDone[i] = true;
                        }
                        else
                        {
                            CheckIsDone[i] = false;
                        }
                    } //                    CheckIsDone[i] = true;
                }
                else
                {
                    CheckIsDone[i] = false;
                    //ntg
                }

                

            }
            for (int i = 0; i < SIZE_ARRAY; i++)
            {
                if (CheckIsDone[i] == true)
                {
                    counter++;
                }
                else
                {
                    counter--;
                    if (counter <= 0)
                    {
                        counter = 0;
                    }
                }

                if (counter >= 5)
                {
                    inventoryScript.closeInventorySlots();
                }
            }
        }

    }

    private void OnMouseEnter()
    {
        hovered = true;
    }

    IEnumerator delayOff()
    {
        yield return new WaitForSeconds(2f);
        inventoryScript.closeInventorySlots();
    }
    
}
