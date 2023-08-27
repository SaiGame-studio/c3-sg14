using UnityEngine;

public class EnemyShipsCtrl : ShipManagerCtrl
{
    [Header("Enemy Ships Ctrl")]
    private static EnemyShipsCtrl instance;
    public static EnemyShipsCtrl Instance => instance;

    public EnemySpawning enemySpawning;
    public BossSpawning bossSpawning;

    protected override void Awake()
    {
        base.Awake();
        if (EnemyShipsCtrl.instance != null) Debug.LogError("Only 1 EnemyShipsCtrl allow to exist");
        EnemyShipsCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBossSpawning();
        this.LoadEnemySpawning();
    }

    protected virtual void LoadBossSpawning()
    {
        if (this.bossSpawning != null) return;
        this.bossSpawning = GetComponentInChildren<BossSpawning>();
        Debug.LogWarning(transform.name + ": LoadBossSpawning", gameObject);
    }

    protected virtual void LoadEnemySpawning()
    {
        if (this.enemySpawning != null) return;
        this.enemySpawning = GetComponentInChildren<EnemySpawning>();
        Debug.LogWarning(transform.name + ": LoadEnemySpawning", gameObject);
    }
}
