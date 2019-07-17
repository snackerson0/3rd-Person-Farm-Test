using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Currency : MonoBehaviour
{
    // Start is called before the first frame update
     private int playersBalance;
    [SerializeField] Text currencyText;
    void Start()
    {
        playersBalance = 0;
        UpdateCurrencyText();
    }


    public int GetPlayersBalance()
    {
        return playersBalance;
    }

    public void AddMoneyToPlayer(int moneyToAdd)
    {
        playersBalance += moneyToAdd;
        print(moneyToAdd + " coins was added");
        UpdateCurrencyText();
    }

    public void DeductMoneyFromPlayer(int moneyToDeduct)
    {
        playersBalance -= moneyToDeduct;
        print(moneyToDeduct + " coins was removed");
        UpdateCurrencyText();
    }

   private void UpdateCurrencyText()
    {
        currencyText.text = GetPlayersBalance().ToString();
    }
}
