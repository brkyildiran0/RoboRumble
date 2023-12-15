using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOrderController : MonoBehaviour
{
    private float _yOffset = 1;
    private float _xOffset = 1;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
            Order(transform, 0, 0);

    }

    private int Order(Transform transformToOrder, int _currentXIncrement, int _currentYIncrement)
    {
        _currentYIncrement += 1;
        transformToOrder.position = startPos + new Vector3(_currentXIncrement * _xOffset, -_currentYIncrement * _yOffset, 0);

        for (int i = 0; i < transformToOrder.childCount; i++)
        {
            _currentYIncrement = Order(transformToOrder.transform.GetChild(i), _currentXIncrement + 1, _currentYIncrement);
        }

        return _currentYIncrement;
    }
}
