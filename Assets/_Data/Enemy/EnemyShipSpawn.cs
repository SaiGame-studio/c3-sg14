using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawn : ShipManagerAbstact
{
    [Header("Enemy Ship Spawn")]
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected int limit = 2;

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }

    protected virtual void Spawning()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        if (this.limit <= this.shipManagerCtrl.shipsManager.Ships.Count) return;
        this.timer = 0;

        ShipMoveFoward shipMoveFoward;

        Transform spawnPoint = this.GetSpawnPos();
        Transform shipObj = EnemyShipsSpawner.Instance.Spawn(this.GetEnemyName(), spawnPoint.position, Quaternion.identity);
        EnemyCtrl shipCtrl = shipObj.GetComponent<EnemyCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);
        shipCtrl.gameObject.SetActive(true);

        ShipStandPos standPoint = this.shipManagerCtrl.pointsManager.StandPoints[0];
        shipMoveFoward = shipCtrl.ObjMovement as ShipMoveFoward;
        if (shipMoveFoward != null)
        {
            shipMoveFoward.SetMoveTarget(standPoint.transform);
            standPoint.SetAbilityObjectCtrl(shipCtrl);
        }
    }

    protected virtual Transform GetSpawnPos()
    {
        Transform respawnPoint;
        respawnPoint = this.shipManagerCtrl.pointsManager.SpawnPoints[0];
        return respawnPoint;
    }

    protected virtual string GetEnemyName()
    {
        return "Enemy_1";
    }
}
