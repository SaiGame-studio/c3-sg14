using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShipAttribute : SaiMonoBehaviour
{
    [SerializeField] protected Attribute attribute;
    [SerializeField] protected TextMeshProUGUI txtAttribute;
    

    private void FixedUpdate()
    {
        this.ShowAttribute();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTxtAttribute();
    }

    protected virtual void LoadTxtAttribute()
    {
        if (this.txtAttribute != null) return;
        this.txtAttribute = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadTxtAttribute", gameObject);
    }

    public virtual void SetAttribute(Attribute attribute)
    {
        this.attribute = attribute;
    }

    protected virtual void ShowAttribute()
    {
        if (attribute == null) return;
        if (attribute.type == AttributeType.noAttribute) return;
        string attrName = this.attribute.type.ToString();
        string text = $"{attrName}: {this.attribute.value}";
        this.txtAttribute.text = text;
    }
}
