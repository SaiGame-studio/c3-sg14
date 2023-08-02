using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetPlayer: FollowTarget
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("PlayerShipsCtrl").transform;
        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }
}
