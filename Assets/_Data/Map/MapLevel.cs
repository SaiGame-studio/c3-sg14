using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel: LevelByDistance
{
    //[Header("Map")]

    private void FixedUpdate()
    {
        this.MapSetTartet();
    }

    protected virtual void MapSetTartet()
    {
        ShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
    }
}
