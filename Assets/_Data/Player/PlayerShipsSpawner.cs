using UnityEngine;

public class PlayerShipsSpawner : Spawner
{
    private static PlayerShipsSpawner instance;
    public static PlayerShipsSpawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerShipsSpawner.instance != null) Debug.LogError("Only 1 ShipsSpawner allow to exist");
        PlayerShipsSpawner.instance = this;
    }

    public virtual Transform Spawn(ShipCode shipCode)
    {
        return this.Spawn(shipCode.ToString(), Vector3.zero, Quaternion.identity);
    }
}
