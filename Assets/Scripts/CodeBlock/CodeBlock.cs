using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CodeBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler//, //IDropHandler
{
    private RectTransform dragTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                CodeBlock codeBlock = result.gameObject.GetComponent<CodeBlock>();
                if (codeBlock != null)
                {
                    Debug.Log("CodeBlock: " + result.gameObject.name);
                }
            }
        }
    }

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
        // canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        dragTransform.SetParent(null);
        // dragTransform.SetAsLastSibling();
        originalParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        dragTransform.anchoredPosition = Input.mousePosition;
        // OnDropped(eventData);
        
        
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

    public void OnDropped(PointerEventData eventData)
    {
        CodeBlock droppedBlock = eventData.pointerDrag.GetComponent<CodeBlock>();

        if (droppedBlock != null) //if dont have parent
        {
            RectTransform droppedRect = droppedBlock.GetComponent<RectTransform>();
            RectTransform thisRect = GetComponent<RectTransform>();

            if (droppedBlock.transform.parent != transform)
            {
                droppedBlock.transform.SetParent(transform);

                Vector2 localPos = Vector2.zero;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRect, eventData.position, eventData.pressEventCamera, out localPos);

                Vector2 newLocalPos = localPos - new Vector2(-30f, thisRect.rect.height + 32f);
                droppedRect.anchoredPosition = newLocalPos;
            }
            else //if it has a parent
            {
                List<RectTransform> childRects = new List<RectTransform>();
                foreach (Transform child in transform)
                {
                    if (child != droppedRect)
                        childRects.Add(child.GetComponent<RectTransform>());
                }

                float yOffset = -32f;
                float currentY = droppedRect.anchoredPosition.y;

                foreach (RectTransform rect in childRects)
                {
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, currentY);
                    currentY += yOffset;
                }

                droppedRect.anchoredPosition = new Vector2(32f, currentY);
            }
        }
    }


}
