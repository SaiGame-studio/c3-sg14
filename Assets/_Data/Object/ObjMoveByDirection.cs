using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    noMove= 0,
    up= 1,
    down = 2,
}

public class ObjMoveByDirection : ObjMovement 
{
    [Header("Move By Direction")]
    [SerializeField] protected MoveDirection moveDirection = MoveDirection.up;
    [SerializeField] protected float offset = 2f;

    protected override void FixedUpdate()
    {
        this.GetMovePosition();
        base.FixedUpdate();
    }

    protected virtual void GetMovePosition()
    {
        Vector3 pos = transform.position;
        if( this.moveDirection == MoveDirection.up) pos.y += this.offset;
        if( this.moveDirection == MoveDirection.down) pos.y -= this.offset;
        this.targetPosition = pos;
    }
}
