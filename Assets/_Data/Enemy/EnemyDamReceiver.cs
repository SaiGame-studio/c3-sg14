using UnityEngine;

public class EnemyDamReceiver : ShootableObjectDamReceiver
{
    protected override void OnDead()
    {
        base.OnDead();
        MapCtrl.Instance.MapLevel.Kill();
    }
}
