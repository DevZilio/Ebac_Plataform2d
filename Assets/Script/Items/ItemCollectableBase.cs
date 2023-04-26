using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected && collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Collect");
        OnCollect();
        collected = true;
        // gameObject.SetActive(false);

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }


    protected virtual void OnCollect() { }
}
