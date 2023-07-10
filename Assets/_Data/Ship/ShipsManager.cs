using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsManager : SaiMonoBehaviour
{
    [SerializeField] protected List<ShipCtrl> ships = new List<ShipCtrl>();
    [SerializeField] protected List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] protected List<Transform> standPoints = new List<Transform>();

    protected override void Start()
    {
        base.Start();
        this.TestAddShips();
        Invoke(nameof(this.SpawnShips), 3);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
        this.LoadStandPoints();
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
        Debug.Log("SpawnShips");

        int index = 0;
        foreach (ShipCtrl shipCtrl in this.ships)
        {
            this.SpawnShip(shipCtrl, index);
            index++;
        }
    }

    protected virtual void SpawnShip(ShipCtrl shipCtrl, int index)
    {
        Transform point;
        ShipMoveFoward shipMoveFoward;

        point = this.spawnPoints[index];
        shipCtrl.transform.position = point.position;
        shipCtrl.gameObject.SetActive(true);

        point = this.standPoints[index];
        shipMoveFoward = shipCtrl.ObjMovement as ShipMoveFoward;
        if(shipMoveFoward != null) shipMoveFoward.SetMoveTarget(point);
    }
}
