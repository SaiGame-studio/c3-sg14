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

    public override void SetLevel(int level)
    {
        base.SetLevel(level);
        this.NumberByLevel();
    }
}
