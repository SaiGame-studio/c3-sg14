using UnityEngine;

public class LevelForDamage : LevelDouble
{
    //[Header("For Damage")]

    protected override void ResetValue()
    {
        this.baseNumber = 1;
        this.baseMin = 1.4f;
        base.ResetValue();
    }
}
