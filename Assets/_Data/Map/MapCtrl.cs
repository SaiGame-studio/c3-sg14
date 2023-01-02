using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : SaiMonoBehaviour
{
    private static MapCtrl instance;
    public static MapCtrl Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MapCtrl.instance != null) Debug.LogError("Only 1 MapManager allow to exist");
        MapCtrl.instance = this;
    }
}
