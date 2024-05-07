using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Object = UnityEngine.Object;

public class BlockMovementController : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IPointerEnterHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    public LayerMask layerMask;
    Collider2D _collider;
    public Execute execute;

    private Vector3 _dragStartMousePosition;

    private Vector3 _dragStartBlockPosition;

    public bool isBeingDragged = false;

    public bool isEndOfStatement = false;
    
    public bool isMovable = true;

    public Camera cam;

    public bool isDropField;

    private RectTransform _currentMinTransform;
    private float _currentMinDistance = 0;

    public RectTransform _mainParent;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        execute = GetComponent<Execute>();
        _rectTransform = GetComponent<RectTransform>();
        _currentMinTransform = _rectTransform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isEndOfStatement)
        {
            return;
        }

        execute.SetEntity(CodeController.Instance.GetSelectedEntity());

        AudioManager.Instance.PlaySFX("ButtonAt");

        Debug.Log("begin drag for " + name);
        _dragStartMousePosition = Input.mousePosition;
        _dragStartBlockPosition = transform.position;
        SetIsDraggedRecursive(true);
        // GetComponent<Image>().raycastTarget = false;

        // var newCollider = transform.AddComponent<BoxCollider2D>();
        // _collider = newCollider;
    }
    

    private void GetClosestTransformToPoint(Vector2 point)
    {
        float minDistance = float.MaxValue;
        RectTransform minTransform = _rectTransform;
            RaycastHit2D[] hits = Physics2D.RaycastAll(point, Vector2.up);
            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<BlockMovementController>() && hit.transform != _rectTransform)
                {
                    if ((point - hit.point).sqrMagnitude < minDistance)
                    {
                        Debug.Log("raycast hit: " + hit.transform.name);
                        minDistance = (point- hit.point).sqrMagnitude;
                        _currentMinDistance = point.y - hit.point.y;
                        minTransform = hit.collider.GetComponent<RectTransform>();
                    }
                }
            }
            
            hits = Physics2D.RaycastAll(point, Vector2.down);

            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<BlockMovementController>() && hit.transform != _rectTransform)
                {
                    if ((point - hit.point).sqrMagnitude < minDistance)
                    {
                        Debug.Log("raycast hit: " + hit.transform.name);
                        minDistance = (point - hit.point).sqrMagnitude;
                        _currentMinDistance = point.y - hit.point.y;
                        minTransform = hit.collider.GetComponent<RectTransform>();
                    }
                }
            }

        _currentMinTransform = minTransform;


    }

    private RectTransform GetParentInBlock(Vector2 pos, out int siblingIndex)
    {
        float offset = 100;
        float difference = _mainParent.position.y - pos.y;
        RectTransform resultParent = _mainParent;
        return GetParentInBlockRecursive(resultParent, difference, out siblingIndex);

    }

    private RectTransform GetParentInBlockRecursive(RectTransform currentTransform, float currentDifference, out int siblingIndex)
    {
        siblingIndex = 0;
        for (int i = 0; i < currentTransform.childCount; i++)
        {
            siblingIndex += 1;
            currentDifference -= 100;
            if (Mathf.Abs(currentDifference) < 100)
            {
                if (Mathf.Abs(currentDifference) < 50)
                {
                    siblingIndex = currentTransform.GetSiblingIndex();
                    return currentTransform;
                }
                // if (currentDifference > 0)
                // {
                    // return currentTransform.parent.GetChild(currentTransform.GetSiblingIndex() - 1);
                // }
                
            }
            else
            {
                return GetParentInBlockRecursive(currentTransform.GetChild(i) as RectTransform, currentDifference, out siblingIndex);
            }
        }

        return currentTransform;

    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (!isMovable)
        {
            return;
        }
        
        EditorUtility.SetDirty(gameObject);
        
        Debug.Log("drag for " +name);
        Vector2 pos;
        _rectTransform.position = _dragStartBlockPosition + Input.mousePosition - _dragStartMousePosition;

        float insideThreshold = 20;


        float overlapHalfEdge = insideThreshold;
        Vector2 topLeftPointOffset = new Vector2(-overlapHalfEdge, overlapHalfEdge);
        Vector2 bottomRightPointoffset = new Vector2(overlapHalfEdge, -overlapHalfEdge);
        Vector2 mousePos = Input.mousePosition;
        List<Collider2D> collidedObjects = new List<Collider2D>();
        
        // var count = Physics2D.OverlapArea(mousePos + topLeftPointOffset, mousePos + bottomRightPointoffset,
            // results);s
            var contactFilter = new ContactFilter2D().NoFilter();
            
        var count = Physics2D.OverlapArea(mousePos + topLeftPointOffset, mousePos + bottomRightPointoffset,contactFilter, collidedObjects);
        Debug.Log("Mouse pos" + mousePos);
        Debug.Log("pos: " + mousePos + " , top left: " + mousePos + topLeftPointOffset + " , bottom right: " + mousePos + bottomRightPointoffset);
        // Collider2D[] collidedObjects = Physics2D.OverlapAreaAll(mousePos + topLeftPointOffset,
            // mousePos + bottomRightPointoffset);
        
        Debug.Log("collided objects: " + count);


        float minDifference = float.MaxValue;
        float yDifference = 0;
        float sign = 1;
        for (int i = 0; i < count; i++)
        {
            Transform raycastTransform = collidedObjects[i].transform;
            if (raycastTransform.GetComponent<BlockMovementController>() && raycastTransform != transform)
            {
                yDifference = raycastTransform.position.y - transform.position.y;
                if (Mathf.Abs(yDifference) < minDifference)
                {
                    minDifference = Mathf.Abs(yDifference);
                    sign = Mathf.Sign(yDifference);
                    _currentMinTransform = raycastTransform as RectTransform;
                }
            }
        }

        _currentMinDistance = sign * minDifference; 

        // GetClosestTransformToPoint(Input.mousePosition);
        
                Debug.Log("inside threshold: " + insideThreshold + ", Y difference: " + _currentMinDistance + ", current collider: " +_currentMinTransform.name);
                if (_currentMinTransform == transform)
                {
                    return;
                }
                if (Mathf.Abs(_currentMinDistance) < insideThreshold)
                {
                    Debug.Log("here 1");
                    transform.SetParent(_currentMinTransform);
                    transform.SetSiblingIndex(0);
                }
                else if (_currentMinDistance < 0) 
                {
                    Debug.Log("here 2");
                    int minTransformSiblingIndex = _currentMinTransform.GetSiblingIndex();
                    transform.SetParent(_currentMinTransform.parent);
                    _currentMinTransform.SetSiblingIndex(minTransformSiblingIndex);
                    transform.SetSiblingIndex(minTransformSiblingIndex - 1);
                }
                else
                {
                    Debug.Log("here 3");
                    int minTransformSiblingIndex = _currentMinTransform.GetSiblingIndex();
                    transform.SetParent(_currentMinTransform.parent);
                    _currentMinTransform.SetSiblingIndex(minTransformSiblingIndex);
                    transform.SetSiblingIndex(minTransformSiblingIndex + 1);
                }
        
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _collider.isTrigger = !_collider.isTrigger;
        EditorUtility.SetDirty(_collider);
        AudioManager.Instance.PlaySFX("ButtonAt");
        SetIsDraggedRecursive(false);
    }
    


    public void OnDrop(PointerEventData eventData)
    {
        return;
        Debug.Log("on dropped activated for " + name + " , dropped object is " + eventData.pointerDrag.name);


        BlockMovementController _droppedController = eventData.pointerDrag.GetComponent<BlockMovementController>();
        Image droppedImage = _droppedController.GetComponent<Image>();
        
        _droppedController.SetIsDraggedRecursive(false);
        droppedImage.raycastTarget = true;
        return;
        Debug.Log(name);
        RectTransform droppedTransform = eventData.pointerDrag.GetComponent<RectTransform>();
        droppedTransform.SetParent(_rectTransform);
        return;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        return;
        Debug.Log("object pos: " + _rectTransform.position);
        Debug.Log("mouse pos: " + Input.mousePosition);
        float magnitude = (_rectTransform.position - Input.mousePosition).magnitude;
            bool hasEntered = magnitude < transform.localScale.x / 2f;
        
            Debug.Log(magnitude);
        if (hasEntered)
        {
            Debug.Log("entered " + name);
            if (eventData.pointerDrag != null)
            {
                BlockMovementController _draggedController = eventData.pointerDrag.GetComponent<BlockMovementController>();
                    Transform _draggedTransform = _draggedController.transform;
                        
                
                _draggedTransform.SetParent(_rectTransform);
                // _draggedTransform.position = _draggedController._dragStartBlockPosition;
                _draggedTransform.SetSiblingIndex(0);
            }
            
        }

            
            
            
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("pointer up on " + name);
        return;
        Debug.Log("Here");
        if (eventData.pointerDrag != null)
        {
            Debug.Log(eventData.pointerDrag.name);
            Debug.Log(":)");
            return;
        }
        Debug.Log(":(");
    }

    private void SetIsDraggedRecursive(bool isDragged)
    {
        isBeingDragged = isDragged;

        for (int i = 0; i < transform.childCount; i++)
        {
            BlockMovementController _blockMovementController = 
            transform.GetChild(i).GetComponent<BlockMovementController>();

            if (_blockMovementController)
            {
                _blockMovementController.SetIsDraggedRecursive(isDragged);
                
            }
        }
    }


}
