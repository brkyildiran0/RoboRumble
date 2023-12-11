using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//put this script on the every element that can be draggable
public class DragObject : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    Vector3 startPosition;
    Vector3 diffPosition;
    GameObject canvas_;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition - diffPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = transform.position;
        diffPosition = Input.mousePosition - startPosition;
        EventSystem.current.SetSelectedGameObject(gameObject);
        EventSystem.current.currentSelectedGameObject.transform.SetParent(canvas_.transform);
        EventSystem.current.currentSelectedGameObject.transform.SetAsFirstSibling();
        Debug.Log("start drag " + gameObject.name);
    }

    void Start()
    {
        canvas_ = GameObject.Find("Canvas");
    }

    void Update()
    {
        
    }

}