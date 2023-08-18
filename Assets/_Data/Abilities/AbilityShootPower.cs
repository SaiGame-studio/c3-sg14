using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShootPower : PassiveAbility
{
    [Header("Shoot Power")]
    [SerializeField] protected PlayerShipCtrl playerShipCtrl;
    [SerializeField] protected ShipAutoShoot shipAutoShoot;
    [SerializeField] protected LevelDouble shipLevel;
    [SerializeField] protected LevelForDamage level;
    [SerializeField] protected int currentStrength = -1;
    [SerializeField] protected int baseNumberMax = 7;
    [SerializeField] protected double damage;

    [SerializeField] protected Attribute strength;

    private void FixedUpdate()
    {
        this.UpdateShootPower();
    }

    protected override void Start()
    {
        base.Start();
        this.LoadStrength();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerShipCtrl();
        this.LoadShipAutoShoot();
        this.LoadShipLevel();
        this.LoadLevel();
    }

    protected virtual void LoadShipLevel()
    {
        if (this.shipLevel != null) return;
        this.shipLevel = this.playerShipCtrl.levelByGold;
        Debug.LogWarning(transform.name + ": LoadLevel", gameObject);
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = GetComponent<LevelForDamage>();
        Debug.LogWarning(transform.name + ": LoadLevel", gameObject);
    }

    protected virtual void LoadPlayerShipCtrl()
    {
        if (this.playerShipCtrl != null) return;
        this.playerShipCtrl = this.abilities.AbilityObjectCtrl as PlayerShipCtrl;
        Debug.LogWarning(transform.name + ": LoadPlayerShipCtrl", gameObject);
    }

    protected virtual void LoadStrength()
    {
        this.strength = this.playerShipCtrl.charAttributes.Get(AttributeType.strength);
    }

    protected virtual void LoadShipAutoShoot()
    {
        if (this.shipAutoShoot != null) return;
        this.shipAutoShoot = this.playerShipCtrl.shipAutoShoot;
        Debug.LogWarning(transform.name + ": LoadDexterity", gameObject);
    }

    protected virtual void UpdateShootPower()
    {
        this.damage = this.GetDamage();
        //this.shipAutoShoot.SetDelay(this.delay);
    }

    protected virtual double GetDamage()
    {
        int strength = this.strength.value;
        if (this.currentStrength == strength) return damage;

        this.currentStrength = strength;
        this.level.baseNumber = 1 + (strength * 0.1f);
        if (this.level.baseNumber > this.baseNumberMax) this.level.baseNumber = this.baseNumberMax;

        this.level.SetLevel(strength);
        this.damage = this.level.Number;
        return this.damage;
    }
}
