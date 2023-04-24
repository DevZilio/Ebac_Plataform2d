using System.Collections;
using System.Collections.Generic;
using DevZilio.Core.Singleton;
using TMPro;
using UnityEngine;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }
}
