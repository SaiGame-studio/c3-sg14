using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemLooter : ItemLooter
{
    protected override void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GameObject.Find("PlayerShipsCtrl").GetComponent<PlayerShipsCtrl>().inventory;
        Debug.LogWarning(transform.name + " LoadInventory", gameObject);
    }
}
