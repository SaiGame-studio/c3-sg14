using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : SaiMonoBehaviour
{
	[Header("Junk Abstract")]
	[SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl { get => junkCtrl; }

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadJunkCtrl();
	}

	protected virtual void LoadJunkCtrl()
	{
		if (this.junkCtrl != null) return;
		this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
		Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
	}
}
