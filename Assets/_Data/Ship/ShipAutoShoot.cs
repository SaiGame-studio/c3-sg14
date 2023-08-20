using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAutoShoot : ObjShooting
{
    [SerializeField] protected double damage = 1;

    protected override bool IsShooting()
    {
        this.isShooting = true;
        return this.isShooting;
    }

    public virtual void SetDamage(double damage)
    {
        this.damage = damage;
    }
}
