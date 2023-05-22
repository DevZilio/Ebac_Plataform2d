using System;
using System.Collections.Generic;
using DevZilio.Core.Singleton;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;

    public SOInt hearts;

    public event Action<int> OnAddHearts;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        hearts.value = 3;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    public void AddHearts(int amount = 1)
    {
        // if(hearts.value <= 2)

        hearts.value += amount;
        OnAddHearts?.Invoke(hearts.value);
    }

    public void LossHearts(int amount = 1)
    {
        hearts.value -= amount;
    }
}
