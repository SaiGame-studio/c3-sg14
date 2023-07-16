using UnityEngine;

public class PlayerShipLookForward: ShipLookForward
{
    //[Header("Player Ship")]

    protected override void ResetValue()
    {
        base.ResetValue();
        this.loopPosition = new Vector3(0, 30, 0);
    }
}
