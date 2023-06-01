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
        LoadData(); // Carrega os dados salvos ao iniciar o jogo
    }

    private void OnDisable()
    {
        SaveData(); // Salva os dados ao desativar o objeto
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

    public int GetTotalCoins()
    {
        return coins.value;
    }

    public void AddHearts(int amount = 1)
    {
        hearts.value += amount;
        OnAddHearts?.Invoke(hearts.value);
    }

    public void LossHearts(int amount = 1)
    {
        hearts.value -= amount;
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("CoinCount", coins.value);
        PlayerPrefs.SetInt("HeartCount", hearts.value);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        coins.value = PlayerPrefs.GetInt("CoinCount", 0);
        hearts.value = PlayerPrefs.GetInt("HeartCount", 3);
    }
}
