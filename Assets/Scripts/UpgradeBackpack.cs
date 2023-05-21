using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBackpack : MonoBehaviour
{
  //These will be visible in the Inspector
    public GameObject slotToDuplicate;
    public Transform parentTransform;
    public Vector2 slotScale;
    public Budget budget;

  //The backpack can only be updgraded 3 times
    private int remainingPresses = 3;

    public void Upgrade()
    {
      //Check if there are remaining button presses and if the money is greater than or equal to 20
        if (remainingPresses > 0 && budget.money >= 20)
        {
          //Make a new copy of the slot
            GameObject newSlot = Instantiate(slotToDuplicate, transform.position, transform.rotation);

          //The slot will be the child of the parent of the slots
            newSlot.transform.SetParent(parentTransform);

          //The slot's size can be changed in the Inspector
            newSlot.transform.localScale = slotScale;

          //Decrease the money by 20, the price of upgrading
            budget.DecreaseMoney(20);

          //Decrease the remaining button presses
            remainingPresses--;
        }
    }
}

