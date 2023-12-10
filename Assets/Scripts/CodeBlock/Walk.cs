using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Execute
{
    public override void ExecuteContent()
    {
        entity.GetMovementController().DisplaceFromCurrentTile(0, 1);
        base.ExecuteContent();
    }
}
