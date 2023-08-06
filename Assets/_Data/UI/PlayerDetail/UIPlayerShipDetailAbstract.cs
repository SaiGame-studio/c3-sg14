using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPlayerShipDetailAbstract : SaiMonoBehaviour
{
    [Header("Player Ship Detail Abstract")]
    public UIPlayerShipDetailCtrl uiPlayerShipDetailCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIPlayerShipDetailCtrl();
    }

    protected virtual void LoadUIPlayerShipDetailCtrl()
    {
        if (this.uiPlayerShipDetailCtrl != null) return;
        this.uiPlayerShipDetailCtrl = transform.parent.GetComponent<UIPlayerShipDetailCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIPlayerShipDetailCtrl", gameObject);
    }

}
