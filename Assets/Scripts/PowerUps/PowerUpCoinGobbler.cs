using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoinGobbler : PowerUpBase
{
    [Header("Power Up Coin Gobbler")]
    public float amountToSpeed;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("COIN GOBBLER");
        //PlayerController.Instance.PowerUpSpeedUp(amountToSpeed);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        //PlayerController.Instance.ResetSpeed();
    }
}
