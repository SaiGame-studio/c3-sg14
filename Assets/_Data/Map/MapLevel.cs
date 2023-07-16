
public class MapLevel : LevelByDistance
{
    //[Header("Map")]

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTartet();
    }

    protected virtual void MapSetTartet()
    {
        if (this.target != null) return;
        if (PlayerCtrl.Instance.CurrentShip == null) return;
        PlayerShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
    }
}
