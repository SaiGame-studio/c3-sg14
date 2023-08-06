using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerShipOnMouseClick : BaseOnMouseClick
{
    protected override void OnMouseClickDown()
    {
        Debug.Log("OnMouseClickDown");
        UIPlayerShipDetailCtrl.Instance.uIAppear.Appear();
    }
}
