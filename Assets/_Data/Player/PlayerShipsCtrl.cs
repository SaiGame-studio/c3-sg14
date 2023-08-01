using UnityEngine;

public class PlayerShipsCtrl : ShipManagerCtrl
{
    private static PlayerShipsCtrl instance;
    public static PlayerShipsCtrl Instance { get => instance; }

    public Inventory inventory;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerShipsCtrl.instance != null) Debug.LogError("Only 1 PlayerShipsCtrl allow to exist");
        PlayerShipsCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }
}
