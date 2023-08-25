using UnityEngine;

public class MapLevel : Level
{
    [Header("Map")]
    public int killCount = 0;
    public int killPerLevel = 16;

    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected virtual void Leveling()
    {
        int newLevel = Mathf.FloorToInt(this.killCount / this.killPerLevel) + 1;
        this.SetLevel(newLevel);
    }

    public virtual void Kill()
    {
        this.killCount++;
    }
}
