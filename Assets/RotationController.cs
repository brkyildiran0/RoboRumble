using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : Execute
{
    private void OnEnable()
    {
        EventManager.RotateEntity += RotateEntity;
    }
    
    private void RotateEntity(Entity entity, int amount)
    {
        if (entity == this.entity)
        {
            RotateObject(amount);
        }
    }
    
    private void RotateObject(int amount )
    {
        transform.GetChild(2).transform.Rotate(0, 0, amount);
    }
}
