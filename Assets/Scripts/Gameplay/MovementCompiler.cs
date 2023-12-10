using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCompiler
{
    private List<Movement> currentMovements;

    public MovementCompiler()
    {
        currentMovements = new List<Movement>();
        EventManager.OnMovement += AddMovementToList;
    }

    private void AddMovementToList(Movement movement)
    {
        currentMovements.Add(movement);
    }

    public void ExecuteMovements()
    {
        int iterationLimit = 100;
        for (int i = 0; i < currentMovements.Count; i++)
        {
            Movement movement = currentMovements[i];
            iterationLimit--;
            if (iterationLimit <= 0)
            {
                break;
            }
            SetTilesForEntity(movement);

            if (movement.entity.GetCollisionController().IsCollidable())
            {
                List<Entity> collidableEntities = movement.entity.GetCollisionController()
                    .GetCollidableEntitiesWithinCollisonRadius(movement.entity.GetCurrentTile());
                foreach (var receiver in collidableEntities)
                {
                    DeleteAllMovementsForEntity(i, movement.entity);
                    Collision collision = new Collision(movement.entity, receiver, movement);
                    EventManager.OnCollision(collision);

                }
            }
        }
        currentMovements.Clear();
    }

    private void DeleteAllMovementsForEntity(int index, Entity entity)
    {
        for (int i = index + 1; i < currentMovements.Count; i++)
        {
            if (currentMovements[i].entity == entity)
            {
                currentMovements.RemoveAt(i);
            }
        }
    }

    private void SetTilesForEntity(Movement movement)
    {
        TileController.Instance.RemoveEntityOnTile(movement.startTile.row, movement.startTile.col, movement.entity);
        TileController.Instance.AssignEntityToTile(movement.endTile.row, movement.endTile.col, movement.entity);
    }

}
