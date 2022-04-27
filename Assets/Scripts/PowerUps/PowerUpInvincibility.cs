using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincibility : PowerUpBase
{
    
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Invincible");
        PlayerController.Instance.PowerUpInvincibility();
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.PowerUpInvincibility(false);
    }

    
}
