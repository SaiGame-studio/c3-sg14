using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipsManager : ShipsManager
{

    protected override void Start()
    {
        base.Start();
        this.TestAddShips();
        Invoke(nameof(this.SpawnShips), 3);
    }
    protected virtual void TestAddShips()
    {
        Transform shipObj;
        ShipCtrl shipCtrl;

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Fighter);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.AddShip(shipCtrl);

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Healer);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.AddShip(shipCtrl);

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Tanker);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.AddShip(shipCtrl);

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Miner);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.AddShip(shipCtrl);
    }

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
