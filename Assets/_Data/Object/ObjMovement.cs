using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : SaiMonoBehaviour
{
    [Header("Obj Movement")]
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected Vector3 offsetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    protected virtual void Moving()
    {
        Vector3 movePos = this.targetPosition;
        movePos.x += this.offsetPosition.x;
        movePos.y += this.offsetPosition.y;
        movePos.z += this.offsetPosition.z;
        this.distance = Vector3.Distance(transform.position, movePos);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, movePos, this.speed);
        transform.parent.position = newPos;
    }

    public virtual void SetOffsetPosition(Vector3 newOffset)
    {
        this.offsetPosition = newOffset;
    }
}
