
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class Execute : MonoBehaviour
{
    private Image _image;
    private Color _startingColor;
    
    public Entity entity;


    private void Awake()
    {
        _image = GetComponent<Image>();
        _startingColor = _image.color;
    }

    public virtual void ExecuteContent()
    {
        // movement scripti


        // entity



        UnSubscribeToTick();
        NotifyParent();
    }

    public void NotifyParent()
    {
        Debug.Log(name);
        transform.parent.GetComponent<Execute>().ChildExecutionComplete(transform.GetSiblingIndex());
    }

    public virtual void ChildExecutionComplete(int childOrder)
    {
    }

    public void SubsribeToTick()
    {
        EventManager.OnTick += ExecuteContent;
        EventManager.OnTick += ScaleAnimation;
    }

    public void UnSubscribeToTick()
    {
        EventManager.OnTick -= ExecuteContent;
        EventManager.OnTick -= ScaleAnimation;
    }

    public void SetEntity(Entity entityToAssign)
    {
        entity = entityToAssign;
        for (int i = 0; i < transform.childCount; i++)
        {
            var execute = transform.GetChild(i).GetComponent<Execute>();
            if (execute)
            {
               execute.SetEntity(entityToAssign); 
            }
        }
    }

    public Execute GetNextExecutor(int currentSiblingIndex)
    {
        for (int i = currentSiblingIndex; i < transform.childCount; i++)
        {
            var execute = transform.GetChild(i).GetComponent<Execute>();
            if (execute)
            {
                return execute;
            }
        }

        return this;
    }


    public void ScaleAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => { _image.color = Color.red; });
        sequence.AppendInterval(TickCounter.Instance.tickInterval);
        sequence.AppendCallback(() => { _image.color = _startingColor; });
    }
}
