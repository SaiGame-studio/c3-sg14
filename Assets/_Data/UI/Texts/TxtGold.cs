using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtGold : BaseText
{
    private void FixedUpdate()
    {
        this.GoldShowing();
    }

    protected virtual void GoldShowing()
    {
        double gold = MoneyManager.Instance.Gold;
        string goldText = $"Gold: {gold}";
        this.text.text = goldText;
    }
}
