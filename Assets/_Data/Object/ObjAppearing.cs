using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppearing : SaiMonoBehaviour
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObjAppearObserver> observers = new List<IObjAppearObserver>();

    public bool IsAppearing => isAppearing;
    public bool Appeared => appeared;

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }

    public virtual void ObserverAdd(IObjAppearObserver observer)
    {
        this.observers.Add(observer);
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach (IObjAppearObserver observer in this.observers)
        {
            observer.OnAppearFinish();
        }
    }
}
