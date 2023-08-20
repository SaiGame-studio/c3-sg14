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
        string goldNumber = LargeNumber.ToString(gold);
        string goldText = $"Gold: {goldNumber}";
        this.text.text = goldText;
    }
}
