

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfCondition : Execute
{
    [SerializeField] private bool isTrue;

    public override void ExecuteContent()
    {
        if (isTrue)
        {
            transform.GetChild(0).GetComponent<Execute>().SubsribeToTick();
        }
        else
        {
            NotifyParent();
        }

        UnSubscribeToTick();
    }

    public override void ChildExecutionComplete(int childOrder)
    {
        if (childOrder < transform.childCount - 1)
        {
            transform.GetChild(childOrder + 1).GetComponent<Execute>().SubsribeToTick();
        }
        else
        {
            NotifyParent();
        }
    }
}