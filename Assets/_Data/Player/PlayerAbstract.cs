using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : SaiMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
