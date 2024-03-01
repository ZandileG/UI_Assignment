using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveChestItem : MonoBehaviour, IDropHandler
{
  //Ihe item will be the child of the new slot that it was dropped in
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            Item_Image item_Image = eventData.pointerDrag.GetComponent<Item_Image>();
            item_Image.parentAfterDrag = transform;
        }
    }

}
