using UnityEngine;

public class LevelForHP : LevelDouble
{
    [Header("For Damage")]
    public EnemyDamReceiver enemyDamReceiver;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.UpdateLevel();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.enemyDamReceiver != null) return;
        this.enemyDamReceiver = transform.parent.GetComponent<EnemyDamReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }

    protected virtual void UpdateLevel()
    {
        int level = MapCtrl.Instance.MapLevel.LevelCurrent;
        this.SetLevel(level);
        this.enemyDamReceiver.SetHPMax(this.number);
        this.enemyDamReceiver.Reborn();
    }
}
