using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy: AbilitySummon
{
    //[Header("Summon Enemy")]

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.LogWarning(transform.name + ": LoadAbilities", gameObject);
    }

}
