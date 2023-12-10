using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkVertical : Execute
{

    public int rowMovementAmount;
    public override void ExecuteContent()
    {
        entity.GetMovementController().DisplaceFromCurrentTileVertically(rowMovementAmount);
        base.ExecuteContent();
    }
}
