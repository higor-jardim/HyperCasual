using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoinGobbler : PowerUpBase
{
    [Header("Power Up Coin Gobbler")]
    public float sizeAmount = 7;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("COIN GOBBLER");
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.ChangeCoinCollectorSize(1);
    }
}
