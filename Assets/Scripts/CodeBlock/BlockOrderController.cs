using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOrderController : MonoBehaviour
{
    private float _yOffset = 100;
    private float _xOffset = 100;

    private Vector3 startPos;

    private RectTransform _rectTransform;

    private RectTransform _requestedTransform;

    private int _requestedX;
    private int _requestedY;

    private void Awake()
    {
        startPos = transform.position;
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
            Order(_rectTransform, 0, 0);
            

    }

    public void RequestTransform(int xOffset, int yOffset)
    {
        _requestedX = xOffset;
        _requestedY = yOffset;
        Order(_rectTransform, 0, 0);
    }

    private int Order( RectTransform transformToOrder, int _currentXIncrement, int _currentYIncrement)
    {
        _currentYIncrement += 1;


        BlockMovementController controllerToOrder = transformToOrder.GetComponent<BlockMovementController>();
        if (!controllerToOrder.isBeingDragged)
        {
            if (controllerToOrder.isEndOfStatement)
            {
                transformToOrder.position = startPos + new Vector3((_currentXIncrement - 1) * _xOffset, -_currentYIncrement * _yOffset, 0);
            }
            else
            {
                transformToOrder.position = startPos + new Vector3(_currentXIncrement * _xOffset, -_currentYIncrement * _yOffset, 0);
            }
        }
        
            

        for (int i = 0; i < transformToOrder.childCount; i++)
        {
            _currentYIncrement = Order(transformToOrder.GetChild(i) as RectTransform, _currentXIncrement + 1, _currentYIncrement);
        }

        return _currentYIncrement;
    }
}
