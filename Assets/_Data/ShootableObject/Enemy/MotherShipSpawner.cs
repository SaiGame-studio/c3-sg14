using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null) Debug.LogError("Only 1 MotherShipSpawner allow to exist");
        MotherShipSpawner.instance = this;
    }
}
