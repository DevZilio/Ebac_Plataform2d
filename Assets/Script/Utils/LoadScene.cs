using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(int i)
    {
        // Obtém a quantidade total de moedas antes de carregar a nova cena
        int totalCoins = ItemManager.Instance.GetTotalCoins();

        // Define a quantidade total de moedas como uma propriedade da nova cena
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        // Carrega a nova cena
        SceneManager.LoadScene(i);
    }

    public void Load(string s)
    {
        // Obtém a quantidade total de moedas antes de carregar a nova cena
        int totalCoins = ItemManager.Instance.GetTotalCoins();

        // Define a quantidade total de moedas como uma propriedade da nova cena
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();

        // Carrega a nova cena
        SceneManager.LoadScene(s);
    }
}
