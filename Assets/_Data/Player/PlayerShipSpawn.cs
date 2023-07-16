using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipSpawn : ShipManagerAbstact
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
        PlayerShipCtrl shipCtrl;

        shipObj = PlayerShipsSpawner.Instance.Spawn(ShipCode.Fighter);
        shipCtrl = shipObj.GetComponent<PlayerShipCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

        shipObj = PlayerShipsSpawner.Instance.Spawn(ShipCode.Healer);
        shipCtrl = shipObj.GetComponent<PlayerShipCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

        shipObj = PlayerShipsSpawner.Instance.Spawn(ShipCode.Tanker);
        shipCtrl = shipObj.GetComponent<PlayerShipCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

        shipObj = PlayerShipsSpawner.Instance.Spawn(ShipCode.Miner);
        shipCtrl = shipObj.GetComponent<PlayerShipCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);
    }

    public virtual void SpawnShips()
    {
        Debug.Log("SpawnShips");

        int index = 0;
        foreach (PlayerShipCtrl shipCtrl in this.shipManagerCtrl.shipsManager.Ships)
        {
            this.SpawnShip(shipCtrl, index);
            index++;
        }
    }

    protected virtual void SpawnShip(PlayerShipCtrl shipCtrl, int index)
    {
        Transform point;
        ShipMoveFoward shipMoveFoward;

        point = this.shipManagerCtrl.pointsManager.SpawnPoints[index];
        shipCtrl.transform.position = point.position;
        shipCtrl.gameObject.SetActive(true);

        point = this.shipManagerCtrl.pointsManager.StandPoints[index];
        shipMoveFoward = shipCtrl.ObjMovement as ShipMoveFoward;
        if (shipMoveFoward != null) shipMoveFoward.SetMoveTarget(point);
    }
}
