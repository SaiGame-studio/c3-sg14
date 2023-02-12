using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ObjMovement 
{
    [Header("Follow Target")]
    [SerializeField] protected Transform target;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadTargetTest();
    }

    protected override void FixedUpdate()
    {
        this.GetTargetPosition();
        base.FixedUpdate();
    }

    protected virtual void LoadTargetTest()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        this.SetTarget(target.transform);
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void GetTargetPosition()
    {
        if (this.target == null) return;
        this.targetPosition = this.target.position;
        this.targetPosition.z = 0;
    }
}
