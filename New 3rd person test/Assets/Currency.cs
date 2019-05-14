using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    // Start is called before the first frame update
     private int playersBalance;
    void Start()
    {
        playersBalance = 0;
    }


    public int GetPlayersBalance()
    {
        return playersBalance;
    }

    public void AddMoneyToPlayer(int moneyToAdd)
    {
        playersBalance += moneyToAdd;
        print(moneyToAdd + " coins was added");
    }

    public void DeductMoneyFromPlayer(int moneyToDeduct)
    {
        playersBalance -= moneyToDeduct;
        print(moneyToDeduct + " coins was removed");
    }
}
