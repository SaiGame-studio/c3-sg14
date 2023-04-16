using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;
    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        //this.Close();

        InvokeRepeating(nameof(this.ShowItems), 1, 1);
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.inventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.inventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.inventoryCtrl.UIInvItemSpawner;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }

        this.SortItems();
    }

    protected virtual void ClearItems()
    {
        this.inventoryCtrl.UIInvItemSpawner.ClearItems();
    }

    protected virtual void SortItems()
    {
        switch (this.inventorySort)
        {
            case InventorySort.ByName:
                this.SortByName();
                break;
            case InventorySort.ByCount:
                Debug.Log("InventorySort.ByCount");
                break;
            default:
                Debug.Log("InventorySort.NoSort");
                break;
        }
    }

    protected virtual void SortByName()
    {
        Debug.Log("== InventorySort.ByName ====");

        int itemCount = this.inventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;

        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.inventoryCtrl.Content.GetChild(i);
            nextItem = this.inventoryCtrl.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfile;
            nextProfile = nextUIItem.ItemInventory.itemProfile;

            currentName = currentProfile.itemName;
            nextName = nextProfile.itemName;

            int compare = string.Compare(currentName, nextName);

            if(compare == 1)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }

            Debug.Log(i + ": " + currentName + " | " + nextName + " = " + compare);
        }

        if (isSorting) this.SortByName();
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

}
