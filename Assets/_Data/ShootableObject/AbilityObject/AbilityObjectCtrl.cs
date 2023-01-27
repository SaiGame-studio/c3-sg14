using UnityEngine;

public abstract class AbilityObjectCtrl : ShootableObjectCtrl
{
    [Header("Ability Object")]
    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = GetComponentInChildren<SpawnPoints>();
        Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
    }
}
