using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    private static UIInvItemSpawner instance;
    public static UIInvItemSpawner Instance => instance;
    public static string normalItem = "UIInvItem";

    [Header("Inv Item Spawner")]
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIInvItemSpawner.instance != null) Debug.LogError("Only 1 UIInvItemSpawner allow to exist");
        UIInvItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtrl();

        if (this.holder != null) return;
        this.holder = this.inventoryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.inventoryCtrl.UIInvItemSpawner.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}
