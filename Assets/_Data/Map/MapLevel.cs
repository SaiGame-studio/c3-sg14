using UnityEngine;

public class MapLevel : Level
{
    //[Header("Map")]

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected virtual void Leveling()
    {
        int bossKillCount = EnemyShipsCtrl.Instance.bossSpawning.KillCount();
        this.SetLevel(bossKillCount + 1);
    }
}
