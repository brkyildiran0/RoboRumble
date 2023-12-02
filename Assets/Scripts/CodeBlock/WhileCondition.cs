using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileCondition : Execute
{
    [SerializeField] private bool isTrue;

    public override void ExecuteContent()
    {
        if (isTrue)
        {
            transform.GetChild(0).GetComponent<Execute>().SubsribeToTick();
            Debug.Log("True");
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
        if (childOrder < transform.childCount - 1)
        {
            transform.GetChild(childOrder + 1).GetComponent<Execute>().SubsribeToTick();
        }
        else
        {
            SubsribeToTick();
        }
    }
}