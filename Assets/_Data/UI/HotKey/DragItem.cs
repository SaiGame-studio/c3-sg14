using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragItem : SaiMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Transform realParent;

    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.Log(transform.name + ": LoadImage", gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        this.realParent = transform.parent;
        transform.SetParent(UIHotKeyCtrl.Instance.transform);
        this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.SetParent(this.realParent);
        this.image.raycastTarget = true;
    }
}
