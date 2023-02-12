using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipModify : ObjModifyAbtract
{
    [Header("Mother Ship")]
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float rotSpeed = 0.01f;

    protected override void Start()
    {
        base.Start();
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        this.shootableObjectCtrl.ObjMovement.SetSpeed(this.speed);
        this.shootableObjectCtrl.ObjLookAtTarget.SetRotSpeed(this.rotSpeed);
    }
}
