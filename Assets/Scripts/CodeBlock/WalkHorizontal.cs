using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkHorizontal : Execute
{

    public int columnMovementAmount;
    public override void ExecuteContent()
    {
        entity.GetMovementController().DisplaceFromCurrentTileHorizontally(columnMovementAmount);
        base.ExecuteContent();
    }
}
