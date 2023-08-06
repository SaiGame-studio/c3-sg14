using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCtrl : AbilityObjectCtrl
{
    [Header("Ship")]
    public CharAttributes charAttributes;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharAttributes();
    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

    protected virtual void LoadCharAttributes()
    {
        if (this.charAttributes != null) return;
        this.charAttributes = GetComponentInChildren<CharAttributes>();
        Debug.LogWarning(transform.name + ": LoadCharAttributes", gameObject);
    }
}
