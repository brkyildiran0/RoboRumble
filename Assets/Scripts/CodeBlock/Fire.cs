using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Execute
{
    //this script should fire the event to fire which raycastlazer will listen to
    //this script will send the information of entity from execute script inside the event when fired
    public override void ExecuteContent()
    {
        EventManager.OnRaycast?.Invoke(entity);
        base.ExecuteContent();
    }
    
}
