using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAttributesLevelSync : SaiMonoBehaviour
{
    public Level level;
    public CharAttributes charAttributes;

    protected void FixedUpdate()
    {
        this.UpdateLevelPoints();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevel();
        this.LoadCharAttributes();
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = transform.parent.GetComponentInChildren<Level>();
        Debug.LogWarning(transform.name + ": LoadLevel", gameObject);
    }

    protected virtual void LoadCharAttributes()
    {
        if (this.charAttributes != null) return;
        this.charAttributes = GetComponent<CharAttributes>();
        Debug.LogWarning(transform.name + ": LoadCharAttributes", gameObject);
    }

    protected virtual void UpdateLevelPoints()
    {
        this.charAttributes.SetLevelPonits(this.level.LevelCurrent);
    }
}
