
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ForCondition : Execute
{
    public Condition condition;

    public override void ExecuteContent()
    {
        if (!condition.IsCounterFinished())
        {
            var execute = transform.GetChild(0).GetComponent<Execute>();
            if (execute)
            {
                execute.SubsribeToTick();
            }
            else
            {
                return;
            }
        }
        else
        {
            NotifyParent();
        }

        UnSubscribeToTick();
    }

    public override void ChildExecutionComplete(int childOrder)
    {
        if (childOrder < transform.childCount - 4)
        {
            transform.GetChild(childOrder + 1).GetComponent<Execute>().SubsribeToTick();
        }
        else
        {
            SubsribeToTick();
        }
    }
}