
public class ShipStandPos : SaiMonoBehaviour
{
    public AbilityObjectCtrl abilityObjectCtrl;

    public virtual void SetAbilityObjectCtrl(AbilityObjectCtrl abilityObjectCtrl)
    {
        this.abilityObjectCtrl = abilityObjectCtrl;
    }

    public virtual bool IsOccupied()
    {
        return this.abilityObjectCtrl != null;
    }
}
