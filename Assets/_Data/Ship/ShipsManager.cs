using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : SaiMonoBehaviour
{
    [SerializeField] protected List<ShipCtrl> ships = new List<ShipCtrl>();

    public virtual void AddShip(ShipCtrl ship)
    {
        this.ships.Add(ship);
    }
}
