using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SellSlot : MonoBehaviour, IDropHandler
{
  //The money will be visible in the Inspector
    public Budget budget;

    public void OnDrop(PointerEventData eventData)
    {
      //Check if the item has a sellable component
        ISellable sellableComponent = eventData.pointerDrag.GetComponent<ISellable>();
        if (sellableComponent != null)
        {
          //Get the sell price from the sellable component
            int sellPrice = sellableComponent.GetSellPrice();

          //Increase the money by the sell price
            budget.IncreaseMoney(sellPrice);

          //The item sold back to the shop disappears in the slot after one second
            StartCoroutine(Disappear(eventData.pointerDrag));
        }
    }

    private IEnumerator Disappear(GameObject item)
    {
        yield return new WaitForSeconds(1f);
        Destroy(item);
    }
}
