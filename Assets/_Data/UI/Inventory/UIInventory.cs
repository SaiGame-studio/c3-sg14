using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : SaiMonoBehaviour
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;
    
    protected bool isOpen = false;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen = false;
    }
}
