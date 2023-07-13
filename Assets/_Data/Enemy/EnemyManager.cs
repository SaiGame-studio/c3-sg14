using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : ShipsManager
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
}
