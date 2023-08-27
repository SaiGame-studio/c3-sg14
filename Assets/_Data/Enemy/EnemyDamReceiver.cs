using UnityEngine;

public class EnemyDamReceiver : ShootableObjectDamReceiver
{
    protected override void OnDead()
    {
        base.OnDead();
        EnemyShipsCtrl.Instance.enemySpawning.Killed();
    }
}
