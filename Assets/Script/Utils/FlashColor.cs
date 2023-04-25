using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DG.Tweening;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color color = Color.red;
    public float duration = .02f;

    private Tween[] _currentTweens;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();

        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }

        _currentTweens = new Tween[spriteRenderers.Count];
    }


    public void Flash()
    {
        //codigo para evitar o DOTween executar antes de ele mesmo terminar
        if (_currentTweens != null)
        {
            foreach (var t in _currentTweens)
            {
                if (t != null)
                {
                    t.Kill();
                }
            }
            spriteRenderers.ForEach(i => i.color = Color.white);

        }

        foreach (var s in spriteRenderers)
        {
            var tween = s.DOColor(color, duration).SetLoops(2, LoopType.Yoyo);
            tween.SetId(s.GetInstanceID());
            _currentTweens[spriteRenderers.IndexOf(s)] = tween;
        }
    }
}