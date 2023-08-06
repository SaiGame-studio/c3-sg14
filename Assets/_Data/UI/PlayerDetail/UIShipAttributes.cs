using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShipAttributes : UIPlayerShipDetailAbstract
{
    [SerializeField] protected UIShipAttribute uiShipAttribute;
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected List<UIShipAttribute> attributes;

    protected override void Awake()
    {
        base.Awake();
        this.CreateAttributes();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIShipAttribtue();
    }

    protected virtual void LoadUIShipAttribtue()
    {
        if (this.uiShipAttribute != null) return;
        this.uiShipAttribute = GetComponentInChildren<UIShipAttribute>();
        this.rectTransform = this.uiShipAttribute.GetComponent<RectTransform>();
        Debug.LogWarning(transform.name + ": LoadUIShipAttribtue", gameObject);
    }

    protected virtual void CreateAttributes()
    {
        float attributeHeight = this.rectTransform.sizeDelta.y;

        int index = 0;
        Vector3 pos;
        foreach (AttributeType type in System.Enum.GetValues(typeof(AttributeType)))
        {
            if (type == AttributeType.noAttribute) continue;

            UIShipAttribute newUIShipAttribute = Instantiate(this.uiShipAttribute, this.uiShipAttribute.transform.parent);
            newUIShipAttribute.name = this.uiShipAttribute.name;
            pos = newUIShipAttribute.transform.localPosition;
            pos.y = (index * attributeHeight)*-1;
            newUIShipAttribute.transform.localPosition = pos;

            this.attributes.Add(newUIShipAttribute);
            index++;
        }

        this.uiShipAttribute.gameObject.SetActive(false);
    }

    public virtual void ShowAttributes()
    {
        Attribute attribute;
        UIShipAttribute uiShipAttribute;
        for (int i = 0; i < this.attributes.Count; i++)
        {
            attribute = this.uiPlayerShipDetailCtrl.playerShipCtrl.charAttributes.Attributes[i];
            uiShipAttribute = this.attributes[i];
            uiShipAttribute.SetAttribute(attribute);
        }
    }
}
