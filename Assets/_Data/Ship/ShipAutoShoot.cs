using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAutoShoot : ObjShooting
{

    protected override bool IsShooting()
    {
        this.isShooting = true;
        return this.isShooting;
    }

}
