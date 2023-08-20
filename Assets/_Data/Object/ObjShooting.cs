using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : SaiMonoBehaviour
{
    [Header("Obj Shooting")]
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected double damage = 1;

    void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.DamageSender.SetDamage(this.damage);
        bulletCtrl.SetShotter(transform.parent);
    }

    public virtual void SetDamage(double damage)
    {
        this.damage = damage;
    }

    public virtual void SetDelay(float delay)
    {
        this.shootDelay = delay;
    }

    protected abstract bool IsShooting();
}
