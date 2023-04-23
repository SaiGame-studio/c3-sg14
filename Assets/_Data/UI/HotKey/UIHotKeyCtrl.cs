using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : SaiMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance { get => instance; }

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 UIHotKeyCtrl allow to exist");
        UIHotKeyCtrl.instance = this;
    }
}
