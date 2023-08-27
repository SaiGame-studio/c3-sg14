using UnityEngine;

public class BossCtrl : AbilityObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Boss.ToString();
    }
}
