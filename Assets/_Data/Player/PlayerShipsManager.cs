using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipsManager : ShipsManager
{
    protected override void SpawnShip(ShipCtrl shipCtrl, int index)
    {
        Transform point;
        ShipMoveFoward shipMoveFoward;

        point = this.spawnPoints[index];
        shipCtrl.transform.position = point.position;
        shipCtrl.gameObject.SetActive(true);

        point = this.standPoints[index];
        shipMoveFoward = shipCtrl.ObjMovement as ShipMoveFoward;
        if (shipMoveFoward != null) shipMoveFoward.SetMoveTarget(point);
    }

    protected virtual int GetIndexFromPlayerIndex()
    {
        int index = 0;

        return index;
    }
}
