using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOnMouseClick : SaiMonoBehaviour
{
    [Header("Base On Mouse Click")]
    [SerializeField] protected Collider _collider;

    protected void OnMouseDown()
    {
        this.OnMouseClickDown();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void OnMouseClickDown()
    {
        //for override
    }
}
