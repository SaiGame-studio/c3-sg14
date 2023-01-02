using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected float distancePerLevel = 70f;

    private void FixedUpdate()
    {
        this.Leveling();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void Leveling()
    {
        if (this.target == null) return;
        this.distance = Vector3.Distance(transform.position, target.position);
        int newLevel = this.GetLevelByDis();
        this.LevelSet(newLevel);
    }

    protected virtual int GetLevelByDis()
    {
        return Mathf.FloorToInt(this.distance / this.distancePerLevel) + 1;
    }
}
