
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Execute : MonoBehaviour
{
    protected Entity entity;
    public virtual void ExecuteContent()
    {
        // movement scripti


        // entity



        UnSubscribeToTick();
        NotifyParent();
    }

    public void NotifyParent()
    {
        transform.parent.GetComponent<Execute>().ChildExecutionComplete(transform.GetSiblingIndex());
    }

    public virtual void ChildExecutionComplete(int childOrder)
    {
    }

    public void SubsribeToTick()
    {
        EventManager.OnTick += ExecuteContent;
    }

    public void UnSubscribeToTick()
    {
        EventManager.OnTick -= ExecuteContent;
    }

    public void SetEntity(Entity entityToAssign)
    {
        entity = entityToAssign;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Execute>().SetEntity(entityToAssign);
        }
    }
    
}
