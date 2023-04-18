using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

public int coins;

//Singleton
public static ItemManager Instance; 

private void Awake() {
    if (Instance == null)
    Instance = this;

    else
    Destroy(gameObject);
}

private void Start()
{
    Reset();
}

private void Reset()
{
    coins = 0;
}

public void AddCoins(int amount = 1)
{
    coins += amount;
}

}
