using System.Collections;
using System.Collections.Generic;
using DevZilio.Core.Singleton;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{

    public SOInt coins;

    // public TextMeshProUGUI uiTextCoins;


    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateUI();
    }


    public void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        // UIInGameManager.UpdateTextCoins(coins.value.ToString());

    }
}