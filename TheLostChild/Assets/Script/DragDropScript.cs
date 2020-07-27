using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropScript : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler
{
	public RectTransform rectTransform;
	public Vector3 StartPos;
	public CanvasGroup canvasGroup;
	public bool isDrop = false;
	public bool isHolding = false;
	public bool isHovered = false;
	public IconParentsScript parentslotscript;

	private void Awake()
	{
		rectTransform = this.gameObject.GetComponent<RectTransform>();
		canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
		parentslotscript = GetComponentInParent<IconParentsScript>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		StartPos =new Vector3(0f,0f,0f);
		canvasGroup.alpha = 0.6f;
		canvasGroup.blocksRaycasts = false;
		isDrop = false;
		isHolding = true;
		parentslotscript.isBacktoBeg = false;
		//Debug.Log("On Begin Drag");
	}

	public void OnDrag(PointerEventData eventData) //IDragHandler
	{
		transform.position = Input.mousePosition;
		isDrop = false;
		isHolding = true;
		parentslotscript.isBacktoBeg = false;
	}

	public void OnEndDrag(PointerEventData eventData) //IEndDragHandler
	{
		isDrop = true;
		isHolding = false;
		canvasGroup.alpha = 1f;
		canvasGroup.blocksRaycasts = true;
		//Debug.Log("On End Drag");
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		//Debug.Log("On Pointer Down");
	}

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
