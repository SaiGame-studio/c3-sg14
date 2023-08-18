using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCtrl : AbilityObjectCtrl
{
    [Header("Ship")]
    public CharAttributes charAttributes;
    public LevelByGold levelByGold;
    public ShipAutoShoot shipAutoShoot;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharAttributes();
        this.LoadLevelByGold();
        this.LoadShipAutoShoot();
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

    protected virtual void LoadShipAutoShoot()
    {
        if (this.shipAutoShoot != null) return;
        this.shipAutoShoot = GetComponentInChildren<ShipAutoShoot>();
        Debug.LogWarning(transform.name + ": LoadShipAutoShoot", gameObject);
    }

    protected virtual void LoadLevelByGold()
    {
        if (this.levelByGold != null) return;
        this.levelByGold = GetComponentInChildren<LevelByGold>();
        Debug.LogWarning(transform.name + ": LoadLevelByGold", gameObject);
    }
}
