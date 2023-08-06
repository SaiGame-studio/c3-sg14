using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppear : SaiMonoBehaviour
{
    [Header("UI Appear")]
    [SerializeField] protected bool show = false;
    [SerializeField] protected float moveSpeed = 7f;
    [SerializeField] protected Vector3 startPos = new Vector3(-1000, 0, 0);
    [SerializeField] protected Vector3 endPos = new Vector3(0, 0, 0);

    private void FixedUpdate()
    {
        this.Showing();
    }

    protected virtual void SetStartPos()
    {
        transform.localPosition = this.startPos;
    }

    public virtual void Appear()
    {
        this.SetStartPos();
        this.show = true;
        transform.gameObject.SetActive(true);

    }

    public virtual void Hide()
    {
        this.show = false;
        transform.gameObject.SetActive(false);
    }

    protected virtual void Showing()
    {
        if (!this.show) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, this.endPos, this.moveSpeed * Time.fixedDeltaTime);
    }
}
