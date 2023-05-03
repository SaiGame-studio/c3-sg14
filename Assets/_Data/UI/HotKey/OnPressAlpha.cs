using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressAlpha : UIHotKeyAbtract
{
    void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if (InputHotKeyManager.Instance.isAlpha1) this.Press(0);
        if (InputHotKeyManager.Instance.isAlpha2) this.Press(1);
        if (InputHotKeyManager.Instance.isAlpha3) this.Press(2);
        if (InputHotKeyManager.Instance.isAlpha4) this.Press(3);
        if (InputHotKeyManager.Instance.isAlpha5) this.Press(4);
        if (InputHotKeyManager.Instance.isAlpha6) this.Press(5);
        if (InputHotKeyManager.Instance.isAlpha7) this.Press(6);
    }

    protected virtual void Press(int alpha)
    {
        Debug.Log("Press: " + alpha);
        ItemSlot itemSlot = this.hotKeyCtrl.itemSlots[alpha];
        Pressable pressable = itemSlot.GetComponentInChildren<Pressable>();
        if (pressable == null) return;
        pressable.Pressed();
    }
}
