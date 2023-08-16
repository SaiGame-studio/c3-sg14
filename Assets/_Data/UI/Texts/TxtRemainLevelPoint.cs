using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtRemainLevelPoint : BaseText
{
    public UIPlayerShipDetailCtrl uiPlayerShipDetailCtrl;

    private void FixedUpdate()
    {
        this.LevelPointShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerShipDetail();
    }

    protected virtual void LoadPlayerShipDetail()
    {
        if (this.uiPlayerShipDetailCtrl != null) return;
        this.uiPlayerShipDetailCtrl = transform.parent.GetComponent<UIPlayerShipDetailCtrl>();
        Debug.LogWarning(transform.name + ": LoadPlayerShipDetail", gameObject);
    }

    protected virtual void LevelPointShowing()
    {
        PlayerShipCtrl playerShipCtrl = this.uiPlayerShipDetailCtrl.playerShipCtrl;
        if (playerShipCtrl == null) return;
        int points = playerShipCtrl.charAttributes.RemainPoints();
        this.text.text = $"Remain: {points}p";
    }
}
