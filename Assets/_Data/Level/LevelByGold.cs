using UnityEngine;

public class LevelByGold : LevelDouble
{
    //[Header("By Gold")]
    //[SerializeField] protected double goldRequire = 1;

    protected override void Start()
    {
        base.Start();
        //Invoke(nameof(TestLevel), 2f);
    }

    protected virtual void TestLevel()
    {
        this.SetLevel(Random.Range(1,5));
    }

    public virtual double GetGoldRequire()
    {
        return this.number;
    }

    public override bool LevelUp()
    {
        if (!this.IsEnoughMoney()) return false;

        MoneyManager.Instance.MinusGold(this.number);
        return base.LevelUp();
    }

    public virtual bool IsEnoughMoney()
    {
        return MoneyManager.Instance.Gold > this.number;
    }
}
