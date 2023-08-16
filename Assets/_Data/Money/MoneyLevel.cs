using UnityEngine;

public class MoneyLevel : LevelDouble
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.LoadLevelFromMap();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

    }

    protected virtual void LoadLevelFromMap()
    {
        int level = MapCtrl.Instance.MapLevel.LevelCurrent;
        this.SetLevel(level);
    }
}
