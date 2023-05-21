using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Budget : MonoBehaviour
{
  //The player's money is visible in the inspector
    public int money = 100;
    public TextMeshProUGUI moneyText;

    public GameObject insufficientFunds;


  //The text update is called
    private void Start()
    {
        UpdateMoneyText();
        CheckZeroMoney();

    }

  //The money decreases when an item is bought from the shop
    public void DecreaseMoney(int price)
    {
        if (price > money)
        {
            StartCoroutine(ShowInsufficientFunds());
            return;
        }
        else if (price == money)
        {
            money -= price;
            UpdateMoneyText();
            return;
        }

        money -= price;
        UpdateMoneyText();
        CheckZeroMoney();
    }

  //The money increases when an item is sold back to the shop
    public void IncreaseMoney(int price)
    {
        money += price;
        UpdateMoneyText();
        CheckZeroMoney();
    }

  //The text will update when something is bought or sold
    private void UpdateMoneyText()
    {
        moneyText.text = money.ToString();
    }

  //Checks if the money is at zero then the insuffient funds message appears for 1 second
    private IEnumerator ShowInsufficientFunds()
    {
        insufficientFunds.SetActive(true);
        yield return new WaitForSeconds(1f);
        insufficientFunds.SetActive(false);
    }

    private void CheckZeroMoney()
    {
        if (money == 0)
        {
            StartCoroutine(ShowInsufficientFunds());
        }
        else
        {
            insufficientFunds.SetActive(false);
        }
    }
}
