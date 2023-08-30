using UnityEngine;

public class BossMoveForwardFix : SaiMonoBehaviour
{
    public ShipMoveForward shipMoveForward;
    [SerializeField] protected Vector3 fixOffset = new Vector3(0, 3, 0);

    protected override void Start()
    {
        base.Start();
        this.shipMoveForward.SetOffsetPosition(this.fixOffset);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipMoveForward();
    }

    protected virtual void LoadShipMoveForward()
    {
        if (this.shipMoveForward != null) return;
        this.shipMoveForward = GetComponent<ShipMoveForward>();
        Debug.LogWarning(transform.name + ": LoadShipMoveForward", gameObject);
    }

}
