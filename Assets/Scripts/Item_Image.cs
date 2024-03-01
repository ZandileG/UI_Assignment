using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item_Image : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ISellable
{
  //The item's image is visible in the Inspector
    [SerializeField] private Image image;
    [HideInInspector] public Transform parentAfterDrag;

  //These are also visible in the Inspector
    public int price;
    public Budget budget;
    public MoveItem backpackItem;

  //Checks if the item was sold
    private bool isSold;


  //This controls what happens when an item is dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
      //Check if the item's price is less than or equal to the available money
        if (price <= budget.money)
        {
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

      //Check if the object is dragged outside of a shop
        if (eventData.pointerCurrentRaycast.gameObject == null || !eventData.pointerCurrentRaycast.gameObject.CompareTag("ShopItem"))
        {
          //Check if the object is dropped into the backpack and hasn't been sold yet
            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("BackpackItem") && !isSold)
            {
              //Decrease the money by the item's price
                budget.DecreaseMoney(price);

              //This makes sure that the money only decreases once, after it is sold
                isSold = true;
            }
        }
    }

    //Gets the item's sell price
    public int GetSellPrice()
    {
        return price;
    }
}
