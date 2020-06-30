using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconParentsScript : MonoBehaviour, IDropHandler
{
	//public static GameObject ChildIcon;
	public DragDropScript dds;
	public bool isBacktoBeg = false;

	private void Start()
	{
		dds = GetComponentInChildren<DragDropScript>();
	}

	void Update()
	{
		DropCheck();
	}

	public void OnDrop(PointerEventData eventData) //IDropHandler
	{
		if(eventData.pointerDrag != null)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = dds.StartPos;
		}
		//dds.gameObject.transform.localPosition = dds.StartPos;
		isBacktoBeg = true;
		dds.isDrop = false;
		dds.isHolding = false;
		dds.canvasGroup.alpha = 1f;
		dds.canvasGroup.blocksRaycasts = true;
		//Debug.Log("Put back in slots");
	}

	public void DropCheck()
	{
		if(dds != null)
		{
			if (dds.isDrop == true && isBacktoBeg == false)
			{
				dds.gameObject.transform.localPosition = dds.StartPos;
				this.gameObject.GetComponentInParent<SlotsScript>().DropItem();
				dds.isDrop = false;
			}
			if (isBacktoBeg == true)
			{
				StartCoroutine(setTofalse());
			}
		}
		else
		{
			return;
		}
	}

	IEnumerator setTofalse()
	{
		yield return new WaitForSeconds(2f);
		isBacktoBeg = false;
		dds.isDrop = false;
	}

}
