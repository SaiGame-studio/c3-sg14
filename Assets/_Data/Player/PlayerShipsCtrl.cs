using UnityEngine;

public class PlayerShipsCtrl : ShipManagerCtrl
{
    private static PlayerShipsCtrl instance;
    public static PlayerShipsCtrl Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (PlayerShipsCtrl.instance != null) Debug.LogError("Only 1 PlayerShipsCtrl allow to exist");
        PlayerShipsCtrl.instance = this;
    }
}
