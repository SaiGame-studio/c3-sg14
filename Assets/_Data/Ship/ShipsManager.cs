using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : SaiMonoBehaviour
{
    [SerializeField] protected List<AbilityObjectCtrl> ships = new List<AbilityObjectCtrl>();
    public List<AbilityObjectCtrl> Ships => ships;

    public virtual void AddShip(AbilityObjectCtrl ship)
    {
        if (this.ships.Contains(ship)) return;
        this.ships.Add(ship);
    }
}
