using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public float duration = .3f;

    private Tween _currentTween;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }


    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flash();
        }
    }

    public void Flash()
    {
        //codigo para evitar o DOTween executar antes de ele mesmo terminar
        if (_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }
        foreach (var s in spriteRenderers)
        {
            s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}