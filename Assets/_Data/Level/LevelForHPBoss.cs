using UnityEngine;

public class LevelForHPBoss : LevelDouble
{
    [Header("For Damage")]
    public BossDamReceiver bossDamReceiver;
    [SerializeField] protected int levelOffset = 7;


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
        if (this.bossDamReceiver != null) return;
        this.bossDamReceiver = transform.parent.GetComponent<BossDamReceiver>();
        Debug.LogWarning(transform.name + ": LoadDamageReceiver", gameObject);
    }

    protected virtual void UpdateLevel()
    {
        int level = MapCtrl.Instance.MapLevel.LevelCurrent + this.levelOffset;
        this.SetLevel(level);
        this.bossDamReceiver.SetHPMax(this.number);
    }
}
