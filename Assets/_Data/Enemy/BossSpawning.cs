using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawning : EnemyShipsAbstact
{
    [Header("Boss Spawning")]
    [SerializeField] protected int enemyKillCount = 0;
    [SerializeField] protected int enemyKillLimit = 16;

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }

    protected virtual void Spawning()
    {
        if (this.enemyKillCount < this.enemyKillLimit) return;
        Debug.Log("BossSpawning Spawning");

        //ShipStandPos playerStandPos = this.GetPlayerStandPos();
        //if (playerStandPos == null) return;

        //ShipSpawnPos spawnPoint = this.GetSpawnPos(playerStandPos);
        //if (spawnPoint == null) return;

        //ShipStandPos standPoint = this.GetStandPos(spawnPoint);
        //if (standPoint == null) return;

        //Transform shipObj = EnemyShipsSpawner.Instance.Spawn(this.GetEnemyName(), spawnPoint.transform.position, Quaternion.identity);
        //EnemyCtrl shipCtrl = shipObj.GetComponent<EnemyCtrl>();
        //this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

        //ShipMoveFoward shipMoveFoward = shipCtrl.ObjMovement as ShipMoveFoward;
        //if (shipMoveFoward != null)
        //{
        //    shipMoveFoward.SetMoveTarget(standPoint.transform);
        //    standPoint.SetAbilityObjectCtrl(shipCtrl);
        //}

        //shipCtrl.gameObject.SetActive(true);
    }

    protected virtual ShipStandPos GetStandPos(ShipSpawnPos spawnPos)
    {
        ShipStandPos standPos = null;

        List<ShipStandPos> positions = this.shipManagerCtrl.pointsManager.StandPoints;
        foreach (ShipStandPos shipStandPos in positions)
        {
            if (shipStandPos.LaneId != spawnPos.LaneId) continue;
            if (shipStandPos.IsOccupied()) continue;

            standPos = shipStandPos;
            break;
        }

        return standPos;
    }

    protected virtual ShipStandPos GetPlayerStandPos()
    {
        List<ShipStandPos> playerStandPoses = PlayerShipsCtrl.Instance.pointsManager.StandPoints;

        ShipStandPos playerStandPos = playerStandPoses[0];
        if (!playerStandPos.IsOccupied()) return null;

        return playerStandPos;
    }

    protected virtual ShipSpawnPos GetSpawnPos(ShipStandPos playerStandPos)
    {
        ShipSpawnPos spawnPos = null;

        List<ShipSpawnPos> positions = this.shipManagerCtrl.pointsManager.SpawnPoints;
        foreach (ShipSpawnPos shipSpawnPos in positions)
        {
            if (shipSpawnPos.LaneId != playerStandPos.LaneId) continue;
            if (shipSpawnPos.IsOccupied()) continue;

            spawnPos = shipSpawnPos;
            break;
        }

        return spawnPos;
    }

    protected virtual string GetEnemyName()
    {
        return "Boss_1";
    }

    public virtual int EnemyKilled()
    {
        this.enemyKillCount++;
        return this.enemyKillCount;
    }
}
