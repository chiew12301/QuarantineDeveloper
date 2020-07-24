using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectorSlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public bool isHovered = false;

	public void OnPointerEnter(PointerEventData data)
	{
		Debug.Log("ok");
		isHovered = true;
	}

	public void OnPointerExit(PointerEventData data)
	{
		isHovered = false;
	}

}
