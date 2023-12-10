using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionCompiler
{
    private List<Collision> currentCollisions;

    public CollisionCompiler()
    {
        currentCollisions = new List<Collision>();
        EventManager.OnCollision += AddCollisionToList;
    }

    private void AddCollisionToList(Collision collision)
    {
        currentCollisions.Add(collision);
    }

    public void ExecuteCollisions()
    {
        int iterationLimit = 100;
        foreach (var collision in currentCollisions)
        {
            iterationLimit--;
            if (iterationLimit <= 0)
            {
                break;
            }
            EntityToEntityCollision(collision);
        }
        currentCollisions.Clear();
    }

    private void EntityToEntityCollision(Collision collision)
    {
        Movement lastMovement = collision.lastMovementOfInitatior;

        int rowChange = lastMovement.startTile.row - lastMovement.endTile.row;
        if (rowChange != 0)
        {
            collision.initiator.GetMovementController().DisplaceFromCurrentTileHorizontally(-rowChange);
        }
        
        int columnChange = lastMovement.startTile.col - lastMovement.endTile.col;
        if (columnChange != 0)
        {
            collision.initiator.GetMovementController().DisplaceFromCurrentTileHorizontally(-columnChange);
        }
    }


}
