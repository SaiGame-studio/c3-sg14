using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDamage : SaiMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponentInChildren<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }

    public virtual void SetDamage(double damage)
    {
        string damageNumber = LargeNumber.ToString(damage);
        this.text.text = damageNumber;
    }
}
