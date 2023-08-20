using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtShipLevel : BaseText
{
    public UIPlayerShipDetailCtrl uiPlayerShipDetailCtrl;

    private void FixedUpdate()
    {
        this.LevelShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerShipDetail();
    }

    protected virtual void LoadPlayerShipDetail()
    {
        if (this.uiPlayerShipDetailCtrl != null) return;
        this.uiPlayerShipDetailCtrl = transform.parent.parent.GetComponent<UIPlayerShipDetailCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerShipDetail", gameObject);
    }

    protected virtual void LevelShowing()
    {
        PlayerShipCtrl playerShipCtrl = this.uiPlayerShipDetailCtrl.playerShipCtrl;
        if (playerShipCtrl == null) return;
        LevelByGold levelByGold = playerShipCtrl.levelByGold;
        int level = levelByGold.LevelCurrent;
        double goldRequire = levelByGold.GetGoldRequire();
        string goldRequireNumber = LargeNumber.ToString(goldRequire);
        this.text.text = $"Level: {level} / {goldRequireNumber}";
    }
}
