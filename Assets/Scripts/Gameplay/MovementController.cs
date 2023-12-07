
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private bool isMovable = true;

    public bool IsMovable()
    {
        return isMovable;
    }

    public void SetIsMovable(bool isMovable)
    {
        this.isMovable = isMovable;
    }

    public void DisplaceFromCurrentTile(Entity entity, int rowMovement, int columnMovement)
    {
        Tile startingTile = 
        Movement()
    }

}