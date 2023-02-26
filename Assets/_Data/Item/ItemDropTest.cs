using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : SaiMonoBehaviour
{
    public JunkCtrl junkCtrl;
    public int dropCount = 0;
    public List<ItemDropCount> dropCountItems = new List<ItemDropCount>();

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Droping), 2, 0.2f);
    }

    protected virtual void Droping()
    {
        this.dropCount += 1;
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropRot);

        ItemDropCount itemDropCount;
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            itemDropCount = this.dropCountItems.Find(i => i.itemName == itemDropRate.itemSO.itemName);
            if (itemDropCount == null)
            {
                itemDropCount = new ItemDropCount();
                itemDropCount.itemName = itemDropRate.itemSO.itemName;
                this.dropCountItems.Add(itemDropCount);
            }

            itemDropCount.count += 1;
            itemDropCount.rate = (float)Math.Round((float)itemDropCount.count / this.dropCount, 2);
        }

    }
}

[Serializable]
public class ItemDropCount
{
    public string itemName;
    public int count;
    public float rate;
}
