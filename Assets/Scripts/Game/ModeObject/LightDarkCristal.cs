using System;
using DG.Tweening;
using Game;
using UnityEngine;

public class LightDarkCristal : MonoBehaviour,ILightDarkBehaviour
{
    private static bool isPickable = false;
    [SerializeField] private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer.DOFade(0f, 0.1f);
    }

    public void OnLight()
    {
        isPickable = true;
        _renderer.DOFade(0f, 0.1f);
    }
    public void OnDark()
    {
        isPickable = false;
        DOVirtual.DelayedCall(1.2f,()=>
        {
            _renderer.DOFade(1, 3f);
        });
    }
}
