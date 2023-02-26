using UnityEngine;

public class ItemDropTest : SaiMonoBehaviour
{
    public JunkCtrl junkCtrl;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Droping), 2, 0.5f);
    }

    protected virtual void Droping()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropRot);
    }
}
