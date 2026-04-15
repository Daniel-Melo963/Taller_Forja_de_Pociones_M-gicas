using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string idIngrediente;
    private Vector3 startPos;
    private Transform parentToReturnTo = null;
    private CanvasGroup group;

    private void Awake() { group = GetComponent<CanvasGroup>(); }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        parentToReturnTo = transform.parent;

        transform.SetParent(transform.parent.parent);

        group.blocksRaycasts = false;
        group.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        group.blocksRaycasts = true;
        group.alpha = 1f;

        
        if (transform.parent != parentToReturnTo)
        {
            transform.SetParent(parentToReturnTo);
            transform.position = startPos;
        }
    }
}

