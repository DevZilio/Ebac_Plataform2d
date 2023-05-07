using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;

    public void killPlayer()
    {
        if (player != null)
        {
            player.DestroyMe();
        }
    }
}
