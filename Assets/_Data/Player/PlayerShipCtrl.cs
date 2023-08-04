using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCtrl : AbilityObjectCtrl
{
    //[Header("Ship")]

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }
}
