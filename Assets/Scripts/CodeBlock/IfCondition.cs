

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfCondition : Execute
{
    public override bool canGetInside => true;
    public bool isElse;
    public bool hasElse;
    public IfCondition elseCondition;
    public Condition condition;


    public override void Awake()
    {
        base.Awake();
        isElse = false;
        if (elseCondition != null)
        {
            elseCondition.gameObject.SetActive(hasElse);
            elseCondition.isElse = true;
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
        Debug.Log("child count " + transform.childCount);
        Debug.Log("child order " + childOrder);

        if (childOrder == transform.childCount - 1)
        {
            NotifyParent();
            return;
        }
        
        var childCount = isElse ? transform.childCount - 3 : transform.childCount - 4;
        if (childOrder != childCount)
        {
            Debug.Log("execute next 8");
            transform.GetChild(childOrder + 1).GetComponent<Execute>().SubsribeToTick();
        }
        else
        {
            Debug.Log("notfying parent 8 ");
            NotifyParent();
        }
    }
}