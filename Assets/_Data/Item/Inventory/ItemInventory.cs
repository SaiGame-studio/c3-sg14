using System;
[Serializable]
public class ItemInventory
{
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;
}
