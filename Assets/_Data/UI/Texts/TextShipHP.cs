using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHP : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }

    protected virtual void UpdateShipHP()
    {
        int hpMx = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
        int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;

        this.text.SetText(hp + "/" + hpMx);
    }
}
