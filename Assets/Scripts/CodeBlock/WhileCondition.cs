
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WhileCondition : Execute
{
    public override bool canGetInside => true;
    
    public Condition condition;
    public override void ExecuteContent()
    {
        if (condition.IsTrue(entity))
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
            Debug.Log("False");
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
            SubsribeToTick();
        }
    }
}
