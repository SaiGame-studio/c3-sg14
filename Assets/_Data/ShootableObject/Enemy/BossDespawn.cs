using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        BossSpawner.Instance.Despawn(transform.parent);
    }
}
