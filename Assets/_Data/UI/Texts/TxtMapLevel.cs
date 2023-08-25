using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TxtMapLevel : BaseText
{
    private void FixedUpdate()
    {
        this.Showing();
    }

    protected virtual void Showing()
    {
        int currentLevel = MapCtrl.Instance.MapLevel.LevelCurrent;
        this.text.text = $"Lv: {currentLevel}";
    }
}
