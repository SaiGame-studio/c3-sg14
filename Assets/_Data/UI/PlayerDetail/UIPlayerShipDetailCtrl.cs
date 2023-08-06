using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerShipDetailCtrl : SaiMonoBehaviour
{
    [Header("Player Ship Detail")]
    private static UIPlayerShipDetailCtrl instance;
    public static UIPlayerShipDetailCtrl Instance { get => instance; }

    public PlayerShipCtrl playerShipCtrl;
    public UIAppear uIAppear;
    public UIShipAttributes uiShipAttributes;

    protected override void Awake()
    {
        base.Awake();
        if (UIPlayerShipDetailCtrl.instance != null) Debug.LogError("Only 1 UIPlayerShipDetail allow to exist");
        UIPlayerShipDetailCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIAppear();
        this.LoadUIShipAttributes();
    }

    protected virtual void LoadUIAppear()
    {
        if (this.uIAppear != null) return;
        this.uIAppear = GetComponent<UIAppear>();
        Debug.LogWarning(transform.name + ": LoadUIAppear", gameObject);
    }

    protected virtual void LoadUIShipAttributes()
    {
        if (this.uiShipAttributes != null) return;
        this.uiShipAttributes = GetComponentInChildren<UIShipAttributes>();
        Debug.LogWarning(transform.name + ": LoadUIShipAttributes", gameObject);
    }

    public virtual void SetPlayerShipCtrl(PlayerShipCtrl playerShipCtrl)
    {
        this.playerShipCtrl = playerShipCtrl;
    }
}
