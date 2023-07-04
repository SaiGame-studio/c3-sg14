using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : SaiMonoBehaviour
{
    [SerializeField] protected List<ShipCtrl> ships = new List<ShipCtrl>();

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.SpawnShips), 3);
    }

    public virtual void AddShip(ShipCtrl ship)
    {
        this.ships.Add(ship);
    }

    public virtual void SpawnShips()
    {
        Debug.Log("SpawnShips");
    }
}
