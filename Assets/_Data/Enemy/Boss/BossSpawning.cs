using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawning : EnemyShipsAbstact
{
    [Header("Boss Spawning")]
    public BossCtrl currentBossCtrl;
    public ShipSpawnPos spawnPos;
    public ShipStandPos standPos;
    [SerializeField] protected int enemyKillCount = 0;
    [SerializeField] protected int enemyKillLimit = 16;
    [SerializeField] protected bool bossSpawned = false;

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipSpawnPos();
        this.LoadShipStandPos();
    }

    protected virtual void LoadShipSpawnPos()
    {
        if (this.spawnPos != null) return;
        List<ShipSpawnPos> positions = this.shipManagerCtrl.pointsManager.SpawnPoints;
        this.spawnPos = positions[0];
        Debug.LogWarning(transform.name + ": LoadShipSpawnPos", gameObject);
    }

    protected virtual void LoadShipStandPos()
    {
        if (this.standPos != null) return;
        List<ShipStandPos> positions = this.shipManagerCtrl.pointsManager.StandPoints;
        this.standPos = positions[0];
        Debug.LogWarning(transform.name + ": LoadShipStandPos", gameObject);
    }

    protected virtual void Spawning()
    {
        if (this.bossSpawned) return;
        if (this.enemyKillCount < this.enemyKillLimit) return;
        Debug.Log("BossSpawning Spawning");
        Vector3 spawnPos = this.spawnPos.transform.position;
        spawnPos.y += 7;
        Transform shipObj = BossSpawner.Instance.Spawn(this.GetEnemyName(), spawnPos, Quaternion.identity);
        this.currentBossCtrl = shipObj.GetComponent<BossCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(this.currentBossCtrl);

        ShipMoveForward shipMoveFoward = this.currentBossCtrl.ObjMovement as ShipMoveForward;
        if (shipMoveFoward != null)
        {
            shipMoveFoward.SetMoveTarget(this.standPos.transform);
            this.standPos.SetAbilityObjectCtrl(this.currentBossCtrl);
        }

        this.currentBossCtrl.gameObject.SetActive(true);
        this.bossSpawned = true;
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

    public override int Killed()
    {
        base.Killed();
        this.currentBossCtrl = null;
        this.bossSpawned = false;
        this.enemyKillCount = 0;
        return this.killCount;
    }
}
