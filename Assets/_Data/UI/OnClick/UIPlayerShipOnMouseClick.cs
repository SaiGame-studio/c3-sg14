using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerShipOnMouseClick : BaseOnMouseClick
{
    public PlayerShipCtrl playerShipCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerShipCtrl();
    }

    protected virtual void LoadPlayerShipCtrl()
    {
        if (this.playerShipCtrl != null) return;
        this.playerShipCtrl = transform.parent.GetComponent<PlayerShipCtrl>();
        Debug.LogWarning(transform.name + ": PlayerShipCtrl", gameObject);
    }

    protected override void OnMouseClickDown()
    {
        Debug.Log("OnMouseClickDown");

        UIPlayerShipDetailCtrl.Instance.SetPlayerShipCtrl(this.playerShipCtrl);
        UIPlayerShipDetailCtrl.Instance.uIAppear.Appear();
        UIPlayerShipDetailCtrl.Instance.uiShipAttributes.ShowAttributes();
    }
}
