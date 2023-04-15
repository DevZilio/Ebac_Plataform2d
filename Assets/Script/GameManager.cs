using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevZilio.Core.Singleton;

public class GameManager : Singleton<GameManager>
{

[Header("Player")]
public GameObject player;

[Header("Enemies")]
public List<GameObject> enemies;
    
}
