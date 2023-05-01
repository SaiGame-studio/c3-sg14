using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressAlpha : SaiMonoBehaviour
{
    void Update()
    {
        this.CheckAlphaIsPress();
    }

    protected virtual void CheckAlphaIsPress()
    {
        if (InputHotKeyManager.Instance.isAlpha1) Debug.Log("isAlpha1");
        if (InputHotKeyManager.Instance.isAlpha2) Debug.Log("isAlpha2");
        if (InputHotKeyManager.Instance.isAlpha3) Debug.Log("isAlpha3");
        if (InputHotKeyManager.Instance.isAlpha4) Debug.Log("isAlpha4");
        if (InputHotKeyManager.Instance.isAlpha5) Debug.Log("isAlpha5");
        if (InputHotKeyManager.Instance.isAlpha6) Debug.Log("isAlpha6");
        if (InputHotKeyManager.Instance.isAlpha7) Debug.Log("isAlpha7");
    }
}
