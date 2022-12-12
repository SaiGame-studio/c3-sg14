using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

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
        //Transform newBullet = Instantiate(this.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
