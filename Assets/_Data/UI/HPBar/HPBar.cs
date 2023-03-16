using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : SaiMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHp sliderHp;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
    }

    protected virtual void LoadSliderHp()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name + ": LoadPlayerPickup", gameObject);
    }

    protected virtual void HPShowing()
    {
        if (this.shootableObjectCtrl == null) return;

        float hp = this.shootableObjectCtrl.DamageReceiver.HP;
        float maxHp = this.shootableObjectCtrl.DamageReceiver.HPMax;

        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(maxHp);
    }

    public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
}
