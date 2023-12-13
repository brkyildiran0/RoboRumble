using UnityEngine;
using UnityEngine.EventSystems;

public class CodeBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private RectTransform dragTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    private void Awake()
    {
        dragTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        originalParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        dragTransform.SetAsLastSibling();
        originalParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out pos);
        dragTransform.position = canvas.transform.TransformPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == originalParent)
        {
            transform.SetParent(originalParent);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        CodeBlock droppedBlock = eventData.pointerDrag.GetComponent<CodeBlock>();

        if (droppedBlock != null)
        {
            droppedBlock.transform.SetParent(transform);

            RectTransform droppedRect = droppedBlock.GetComponent<RectTransform>();
            RectTransform thisRect = GetComponent<RectTransform>();

            Vector2 localPos = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRect, eventData.position, eventData.pressEventCamera, out localPos);

            Vector2 newLocalPos = localPos - new Vector2(0f, thisRect.rect.height + 32f);
            droppedRect.localPosition = newLocalPos;
        }
    }


}
