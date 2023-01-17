using UnityEngine;

public class Level : SaiMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 0;
    [SerializeField] protected int levelMax = 99;
    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;

    public virtual void LevelUp()
    {
        this.levelCurrent += 1;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel)
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }

    protected virtual void LimitLevel()
    {
        if (this.levelCurrent > this.levelMax) this.levelCurrent = this.levelMax;
        if (this.levelCurrent < 1) this.levelCurrent = 1;
    }
}
