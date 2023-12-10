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
        foreach (var movement in currentMovements)
        {
            SetTilesForEntity(movement);
        }
        currentMovements.Clear();
    }

    private void SetTilesForEntity(Movement movement)
    {
        TileController.Instance.RemoveEntityOnTile(movement.startTile.row, movement.startTile.col, movement.entity);
        TileController.Instance.AssignEntityToTile(movement.endTile.row, movement.endTile.col, movement.entity);
    }

}