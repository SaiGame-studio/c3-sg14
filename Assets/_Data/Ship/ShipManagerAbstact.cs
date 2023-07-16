using UnityEngine;

public abstract class ShipManagerAbstact : SaiMonoBehaviour
{
    [Header("Ship Manager Abstact")]
    public ShipManagerCtrl shipManagerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipManagerCtrl();
    }

    protected virtual void LoadShipManagerCtrl()
    {
        if (this.shipManagerCtrl != null) return;
        this.shipManagerCtrl = transform.parent.GetComponent<ShipManagerCtrl>();
        Debug.LogWarning(transform.name + ": LoadShipManagerCtrl", gameObject);
    }

}
