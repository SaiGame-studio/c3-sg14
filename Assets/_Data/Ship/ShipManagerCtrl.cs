using UnityEngine;

public abstract class ShipManagerCtrl : SaiMonoBehaviour
{
    [Header("Ship Manager Ctrl")]
    public PointsManager pointsManager;
    public ShipsManager shipsManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPointsManager();
        this.LoadShipsManager();
    }

    protected virtual void LoadPointsManager()
    {
        if (this.pointsManager != null) return;
        this.pointsManager = transform.GetComponentInChildren<PointsManager>();
        Debug.LogWarning(transform.name + ": LoadPointsManager", gameObject);
    }

    protected virtual void LoadShipsManager()
    {
        if (this.shipsManager != null) return;
        this.shipsManager = transform.GetComponentInChildren<ShipsManager>();
        Debug.LogWarning(transform.name + ": LoadShipsManager", gameObject);
    }
}
