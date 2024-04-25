using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Execute
{
    //this script should fire the event to fire which raycastlazer will listen to

    public override void ExecuteContent()
    {
        EventManager.OnRaycast?.Invoke();
        base.ExecuteContent();
    }
}
