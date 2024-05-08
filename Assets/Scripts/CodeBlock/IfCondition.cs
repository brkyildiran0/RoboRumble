

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfCondition : Execute
{
    public bool hasElse;
    public IfCondition elseCondition;
    public Condition condition;


    public override void Awake()
    {
        base.Awake();
        if (elseCondition != null)
        {
            elseCondition.gameObject.SetActive(hasElse);
        }
    }
    
    public override void ExecuteContent()
    {
        if (condition.IsTrue(entity))
        {
            Debug.Log("condition is true");
            var execute = transform.GetChild(0).GetComponent<Execute>();
            if (execute)
            {
                execute.SubsribeToTick();
            }
            else
            {
                NotifyParent();
            }
        }
        else
        {
            if (hasElse)
            {
                elseCondition.SubsribeToTick();
            }
            else
            {
                NotifyParent();
            }
        }

        UnSubscribeToTick();
    }

    public override void ChildExecutionComplete(int childOrder)
    {
        if (childOrder < transform.childCount - 3)
        {
            transform.GetChild(childOrder + 1).GetComponent<Execute>().SubsribeToTick();
        }
        else
        {
            NotifyParent();
        }
    }
}