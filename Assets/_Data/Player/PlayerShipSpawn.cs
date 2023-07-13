using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipSpawn : ShipSpawnManager
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
        this.shipsManager.AddShip(shipCtrl);

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Healer);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.shipsManager.AddShip(shipCtrl);

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Tanker);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.shipsManager.AddShip(shipCtrl);

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Miner);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.shipsManager.AddShip(shipCtrl);
    }

}
