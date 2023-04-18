using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{

    public Animator animator;

    protected override void OnCollect()
    {
        base.OnCollect();
        animator.SetTrigger("Collected");
        Destroy(gameObject, 1);
        
        ItemManager.Instance.AddCoins();
    }
}
