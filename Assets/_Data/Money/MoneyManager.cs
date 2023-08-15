using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] protected double gold;
    public double Gold => gold;

    public virtual void AddGold(double number)
    {
        this.gold += number;
    }

    public virtual bool MinusGold(double number)
    {
        double newGold = this.gold - number;
        if (newGold <= 0) return false;
        this.gold = newGold;
        return true;
    }

    public virtual void Add(ItemCode itemCode, double number)
    {
        if (itemCode == ItemCode.Gold) this.AddGold(number);
    }
}
