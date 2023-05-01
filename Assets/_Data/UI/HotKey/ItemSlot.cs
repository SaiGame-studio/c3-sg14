using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : SaiMonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0) return;
        Debug.Log("OnDrop");
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        dragItem.SetRealParent(transform);
    }
}
