using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttributes : SaiMonoBehaviour
{
    [SerializeField] protected int maxPoint = 7;
    public int MaxPoint => maxPoint;

    [SerializeField] protected int currentPoint = 0;
    public int CurrentPoint => currentPoint;

    [SerializeField] protected List<Attribute> attributes;
    public List<Attribute> Attributes => attributes;

    protected override void Start()
    {
        base.Start();
        Invoke("Test", 3);
    }

    protected virtual void Test()
    {
        this.Add(AttributeType.strength, 4);
        this.Add(AttributeType.luck, 3);
        this.Deduct(AttributeType.strength, 1);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttributes();
    }

    protected virtual void LoadAttributes()
    {
        if (this.attributes.Count > 0) return;
        foreach (AttributeType type in System.Enum.GetValues(typeof(AttributeType)))
        {
            if (type == AttributeType.noAttribute) continue;

            Attribute attribute = new Attribute
            {
                type = type
            };
            this.attributes.Add(attribute);
        }
        Debug.LogWarning(transform.name + ": LoadAttributes", gameObject);
    }

    public virtual Attribute Get(AttributeType type)
    {
        return this.attributes.Find(attr => attr.type == type);
    }

    public virtual bool Add(AttributeType type, int add)
    {
        int newCurrentPoint = this.currentPoint + add;
        if (newCurrentPoint > this.maxPoint) return false;

        this.currentPoint = newCurrentPoint;
        Attribute attr = this.Get(type);
        attr.value += add;

        return true;
    }

    public virtual void Deduct(AttributeType type, int deduct)
    {
        Attribute attr = this.Get(type);
        attr.value -= deduct;
        this.currentPoint -= deduct;
        if (attr.value < 0) attr.value = 0;
    }
}
