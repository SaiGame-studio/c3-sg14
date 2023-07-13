using System.Collections.Generic;
using UnityEngine;

public abstract class ShipsManager : SaiMonoBehaviour
{
    [SerializeField] protected List<ShipCtrl> ships = new List<ShipCtrl>();
    [SerializeField] protected List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] protected List<Transform> standPoints = new List<Transform>();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
        this.LoadStandPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        Transform points = transform.Find("SpawnPoints");
        foreach (Transform point in points)
        {
            this.spawnPoints.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }

    protected virtual void LoadStandPoints()
    {
        if (this.standPoints.Count > 0) return;
        Transform points = transform.Find("StandPoints");
        foreach (Transform point in points)
        {
            this.standPoints.Add(point);
        }
        Debug.LogWarning(transform.name + ": LoadStandPoints", gameObject);
    }

    public virtual void AddShip(ShipCtrl ship)
    {
        this.ships.Add(ship);
    }

    public virtual void SpawnShips()
    {
        int index = 0;
        foreach (ShipCtrl shipCtrl in this.ships)
        {
            this.SpawnShip(shipCtrl, index);
            index++;
        }
    }

    protected abstract void SpawnShip(ShipCtrl shipCtrl, int index);
}
