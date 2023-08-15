using UnityEngine;

public class LevelByGold : LevelDouble
{
    [Header("By Gold")]
    [SerializeField] protected double goldRequire = 1;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(TestLevel), 2f);
    }

    protected virtual void TestLevel()
    {
        this.SetLevel(Random.Range(10,100));
        this.GetGoldRequire();
    }

    protected virtual void GetGoldRequire()
    {

    }
}
