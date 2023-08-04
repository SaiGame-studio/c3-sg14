using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        //ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (PlayerShipsCtrl.Instance.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
