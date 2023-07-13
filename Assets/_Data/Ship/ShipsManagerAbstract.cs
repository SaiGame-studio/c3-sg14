using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipsManagerAbstract : SaiMonoBehaviour
{
    [Header("Ship Manager Abstract")]
    public ShipsManager shipsManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipsManager();
    }

    protected virtual void LoadShipsManager()
    {
        if (this.shipsManager != null) return;
        this.shipsManager = transform.parent.GetComponent<ShipsManager>();
        Debug.LogWarning(transform.name + ": LoadShipsManager", gameObject);
    }

}
