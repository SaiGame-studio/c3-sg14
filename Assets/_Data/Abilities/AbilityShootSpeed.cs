using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShootSpeed : PassiveAbility
{
    [Header("Shoot Speed")]
    [SerializeField] protected PlayerShipCtrl playerShipCtrl;
    [SerializeField] protected ShipAutoShoot shipAutoShoot;
    [SerializeField] protected float startDelay = 1f;
    [SerializeField] protected float delay = 1f;
    [SerializeField] protected float minDelay = 0.01f;

    [SerializeField] protected Attribute dexterity;

    private void FixedUpdate()
    {
        this.UpdateAttackSpeed();
    }

    protected override void Start()
    {
        base.Start();
        this.LoadDexterity();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerShipCtrl();
        this.LoadShipAutoShoot();
    }

    protected virtual void LoadPlayerShipCtrl()
    {
        if (this.playerShipCtrl != null) return;
        this.playerShipCtrl = this.abilities.AbilityObjectCtrl as PlayerShipCtrl;
        Debug.LogWarning(transform.name + ": LoadPlayerShipCtrl", gameObject);
    }

    protected virtual void LoadDexterity()
    {
        this.dexterity = this.playerShipCtrl.charAttributes.Get(AttributeType.dexterity);
    }

    protected virtual void LoadShipAutoShoot()
    {
        if (this.shipAutoShoot != null) return;
        this.shipAutoShoot = this.playerShipCtrl.shipAutoShoot;
        Debug.LogWarning(transform.name + ": LoadDexterity", gameObject);
    }

    protected virtual void UpdateAttackSpeed()
    {
        this.delay = this.GetDelay();
        this.shipAutoShoot.SetDelay(this.delay);
    }

    protected virtual float GetDelay()
    {
        int dex = this.dexterity.value;
        this.delay = this.startDelay - (dex * 0.01f);
        if (this.delay < this.minDelay) this.delay = this.minDelay;
        return this.delay;
    }
}
