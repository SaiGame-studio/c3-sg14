using UnityEngine;

public class EnemyShipsSpawner : Spawner
{
    private static EnemyShipsSpawner instance;
    public static EnemyShipsSpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (EnemyShipsSpawner.instance != null) Debug.LogError("Only 1 EnemyShipsSpawner allow to exist");
        EnemyShipsSpawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);

        return newEnemy;
    }

    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHpBar.gameObject.SetActive(true);
    }
}
