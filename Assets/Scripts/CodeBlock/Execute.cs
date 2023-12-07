
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Execute : MonoBehaviour
{
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

}
