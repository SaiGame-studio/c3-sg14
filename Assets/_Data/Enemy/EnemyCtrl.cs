using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
