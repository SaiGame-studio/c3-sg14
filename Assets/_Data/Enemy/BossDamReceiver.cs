using UnityEngine;

public class BossDamReceiver : ShootableObjectDamReceiver
{
    protected override void OnDead()
    {
        base.OnDead();
        EnemyShipsCtrl.Instance.bossSpawning.Killed();
    }
}
