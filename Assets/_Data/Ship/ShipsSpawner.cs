using UnityEngine;

public class ShipsSpawner : Spawner
{
    private static ShipsSpawner instance;
    public static ShipsSpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (ShipsSpawner.instance != null) Debug.LogError("Only 1 ShipsSpawner allow to exist");
        ShipsSpawner.instance = this;
    }

    public virtual Transform Spawn(ShipCode shipCode)
    {
        return this.Spawn(shipCode.ToString(), Vector3.zero, Quaternion.identity);
    }
}
