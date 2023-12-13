using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    public VerticalLayoutGroup verticalLayout;

    public void OnDrop(PointerEventData eventData)
    {
        CodeBlock codeBlock = eventData.pointerDrag.GetComponent<CodeBlock>();

        if (codeBlock != null)
        {
            codeBlock.transform.SetParent(transform);

            int index = transform.childCount - 1;
            RectTransform itemRect = codeBlock.GetComponent<RectTransform>();
            Vector2 itemSize = itemRect.rect.size;

            float yPos = -index * itemSize.y;

            itemRect.anchoredPosition = new Vector2(0f, yPos);

            ResizeParentContainer();
        }
    }

    void ResizeParentContainer()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(verticalLayout.GetComponent<RectTransform>());
    }
}
