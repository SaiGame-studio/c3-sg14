using UnityEngine;

public class MoneyCtrl : ItemCtrl
{
    [Header("Money")]
    [SerializeField] protected MoneyLevel moneyLevel;
    public MoneyLevel MoneyLevel => moneyLevel;


    protected override void ResetValue()
    {
        base.ResetValue();
        this.itemInventory.itemCount = 0;
        this.itemInventory.maxStack = 0;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoneyLevel();
    }

    protected virtual void LoadMoneyLevel()
    {
        if (this.moneyLevel != null) return;
        this.moneyLevel = transform.GetComponentInChildren<MoneyLevel>();
        Debug.Log(transform.name + ": LoadMoneyLevel", gameObject);
    }
}
