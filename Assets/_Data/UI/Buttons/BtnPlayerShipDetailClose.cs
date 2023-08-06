using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlayerShipDetailClose : BaseButton
{
    protected override void OnClick()
    {
        UIPlayerShipDetailCtrl.Instance.uIAppear.Hide();
    }
}
