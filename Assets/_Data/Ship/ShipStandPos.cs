using UnityEngine;

public class ShipStandPos : SaiMonoBehaviour
{
    public AbilityObjectCtrl abilityObjectCtrl;
    [SerializeField] protected int laneId = -1;
    [SerializeField] protected int maxLane = 5;

    public int LaneId => laneId;

    protected override void Awake()
    {
        base.Awake();
        this.LoadLaneId();
    }

    protected virtual void FixedUpdate()
    {
        this.CheckObjectStatus();
    }

    protected virtual void CheckObjectStatus()
    {
        if (this.abilityObjectCtrl == null) return;
        if (this.abilityObjectCtrl.gameObject.activeSelf == true) return;

        this.SetAbilityObjectCtrl(null);
    }

    protected virtual void LoadLaneId()
    {
        string name = transform.name;
        string numberPart = name.Substring(name.IndexOf('_') + 1);
        this.laneId = int.Parse(numberPart) % this.maxLane;
        if (this.laneId == 0) laneId = this.maxLane;
    }

    public virtual void SetAbilityObjectCtrl(AbilityObjectCtrl abilityObjectCtrl)
    {
        this.abilityObjectCtrl = abilityObjectCtrl;
    }

    public virtual bool IsOccupied()
    {
        return this.abilityObjectCtrl != null;
    }
}
