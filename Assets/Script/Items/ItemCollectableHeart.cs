using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableHeart : ItemCollectableBase
{

// public Animator animator;

public Collider2D collider;
    
    protected override void OnCollect()
    {
        base.OnCollect();

        collider.enabled = false;

        ItemManager.Instance.AddHearts();

        Destroy(gameObject,0);
    }

      // Update function called every frame
    private void Update()
    {
        // // Check if the "Collected" animation state has finished and re-enable the Collider2D component
        // if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
        // {
        // }
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }
    }
}
