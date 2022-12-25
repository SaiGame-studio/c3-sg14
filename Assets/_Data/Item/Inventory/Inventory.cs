using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SaiMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);

        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool DeductItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - addCount;
        if (newCount < 0) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool TryDeductItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - addCount;
        if (newCount < 0) return false;
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
