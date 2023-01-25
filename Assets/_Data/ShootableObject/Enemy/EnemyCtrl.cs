using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
