using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickupable: ItemPickupable 
{
    [Header("Money Pickupable")]
    [SerializeField] protected MoneyCtrl moneyCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadMoneyCtrl();
	}

	protected virtual void LoadMoneyCtrl()
	{
		if (this.moneyCtrl != null) return;
		this.moneyCtrl = transform.parent.GetComponent<MoneyCtrl>();
		Debug.Log(transform.name + ": LoadMoneyCtrl", gameObject);
	}

	public override void Picked()
	{
		double money = this.moneyCtrl.MoneyLevel.Number;
		ItemCode itemCode = this.itemCtrl.ItemInventory.itemProfile.itemCode;
		MoneyManager.Instance.Add(itemCode, money);
		base.Picked();
	}
}
