using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleBounce = .1f;
    public Ease ease = Ease.OutBack;

    

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }
}
