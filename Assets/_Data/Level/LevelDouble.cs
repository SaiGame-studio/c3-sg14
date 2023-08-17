using UnityEngine;

public class LevelDouble : Level
{

    [Header("Double")]
    [SerializeField] protected double baseNumber = 10;
    [SerializeField] protected double baseMin = 1.3;
    [SerializeField] protected double baseMax = 1.0712;
    [SerializeField] protected double baseLimit = 100;
    [SerializeField] protected double number = 0;
    [SerializeField] protected float numberMulti = 1f;

    public double Number => number;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetLevel(1);
    }

    public virtual double NumberByLevel()
    {

        //= ROUND(number * base_min ^ MIN(B9, hp_base_limit) * hp_base_max ^ MAX(0, B9 - hp_base_limit), trunc)
        this.number = this.baseNumber * System.Math.Pow(baseMin, System.Math.Min(this.levelCurrent, baseLimit)) * System.Math.Pow(baseMax, System.Math.Max(0, this.levelCurrent - baseLimit));
        this.number *= this.numberMulti;

        return this.number;
    }

    public virtual double NumberByLevel(int level)
    {
        this.SetLevel(level);
        return this.NumberByLevel();
    }

    public override bool SetLevel(int level)
    {
        bool status = base.SetLevel(level);
        this.NumberByLevel();
        return status;
    }

    public override bool LevelUp()
    {
        bool status = base.LevelUp();
        this.NumberByLevel();
        return status;
    }
}
