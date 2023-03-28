using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [Header("Inv Item Spawner")]
    [SerializeField] protected UIInvItemSpawner invItemSpawner;
    public UIInvItemSpawner UIInvItemSpawner => invItemSpawner;

    protected override void Start()
    {
        base.Start();

        for (int i = 1; i < 70; i++)
        {
            this.SpawnTest(i);
        }
    }

    protected virtual void SpawnTest(int i)
    {
        Transform uiItem = this.UIInvItemSpawner.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);
        uiItem.name = "Item_" + i;
        uiItem.gameObject.SetActive(true);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInvItemSpawner();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadUIInvItemSpawner()
    {
        if (this.invItemSpawner != null) return;
        this.invItemSpawner = transform.GetComponentInChildren<UIInvItemSpawner>();
        Debug.Log(transform.name + ": LoadUIInvItemSpawner", gameObject);
    }
}
