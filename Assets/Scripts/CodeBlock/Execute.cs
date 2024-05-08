
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public abstract class Execute : MonoBehaviour
{
    public virtual bool canGetInside => false;

    private Image _image;
    private Color _startingColor;
    private Sequence _sequence;
    
    public Entity entity;


    public virtual void Awake()
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
        Debug.Log("notify8: " + name);
        transform.parent.GetComponent<Execute>().ChildExecutionComplete(transform.GetSiblingIndex());
    }

    public virtual void ChildExecutionComplete(int childOrder)
    {
    }

    public void SubsribeToTick()
    {
        Debug.Log("subscribed to tick");
        EventManager.OnTick += ExecuteContent;
        EventManager.OnTick += ScaleAnimation;
    }

    private void OnDestroy()
    {
        UnSubscribeToTick();
    }

    public void UnSubscribeToTick()
    {
        Debug.Log("unsubscribed to tick");
        EventManager.OnTick -= ExecuteContent;
        EventManager.OnTick -= ScaleAnimation;
        _sequence?.Kill();
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

    public Entity GetEntity()
    {
        if (entity != null)
        {
            return entity;
        }
        return null;
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
        _sequence = DOTween.Sequence();
        _sequence.AppendCallback(() => { _image.color = Color.red; });
        _sequence.AppendInterval(TickCounter.Instance.tickInterval);
        _sequence.AppendCallback(() => { _image.color = _startingColor; });
    }
}
