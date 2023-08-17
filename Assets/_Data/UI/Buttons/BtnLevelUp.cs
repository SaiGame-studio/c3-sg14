using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLevelUp : BaseButton
{
    public UIPlayerShipDetailCtrl uiPlayerShipDetailCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.UIPlayerShipDetailCtrl();
    }

    protected virtual void UIPlayerShipDetailCtrl()
    {
        if (this.uiPlayerShipDetailCtrl != null) return;
        this.uiPlayerShipDetailCtrl = transform.parent.parent.GetComponent<UIPlayerShipDetailCtrl>();
        Debug.LogWarning(transform.name + ": UIPlayerShipDetailCtrl", gameObject);
    }

    protected override void OnClick()
    {
        this.uiPlayerShipDetailCtrl.playerShipCtrl.levelByGold.LevelUp();
    }
}
