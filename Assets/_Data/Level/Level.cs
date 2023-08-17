using UnityEngine;

public class Level : SaiMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 0;
    [SerializeField] protected int levelMax = 1000;
    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;

    public virtual bool LevelUp()
    {
        int newLevel = this.levelCurrent + 1;
        if (newLevel > this.levelMax) return false;

        this.levelCurrent += 1;
        return true;
    }

    public virtual bool SetLevel(int newLevel)
    {
        if (newLevel > this.levelMax) return false;
        if (newLevel < 1) return false;

        this.levelCurrent = newLevel;
        return true;
    }
}
