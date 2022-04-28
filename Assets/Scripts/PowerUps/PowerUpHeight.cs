using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpHeight : PowerUpBase
{
    [Header("Power Up Height")]
    public float amountToRise = 2;
    public float animationDuration = .1f;
    public Ease ease = Ease.OutBack;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Height Up");
        PlayerController.Instance.ChangeHeight(amountToRise, duration, animationDuration, ease);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.ResetHeight();
    }
}
