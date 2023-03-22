using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInventoryOpen : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
}
