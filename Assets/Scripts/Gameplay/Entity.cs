

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    private Tile currentTile;
    private MovementController movementController;
    private CollisionController collisionController;
    

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
        collisionController = GetComponent<CollisionController>();
        movementController.SetCurrentMovement(new Movement(null, null, this));
    }

    public Tile GetCurrentTile()
    {
        return currentTile;
    }

    public void SetCurrentTile(Tile tile)
    {
        Debug.Log("tile set to " + currentTile);
        currentTile = tile;
    }

    public MovementController GetMovementController()
    {
        movementController.SetCurrentMovement(new Movement(currentTile, null, this));
        return movementController;
    }

    public CollisionController GetCollisionController()
    {
        return collisionController;
    }

    public int GetValue(Condition.SymbolType symbolType)
    {
        switch (symbolType)
        {
            case(Condition.SymbolType.xPos):
                return currentTile.col;
            case(Condition.SymbolType.yPos):
                return currentTile.row;
            default:
                return 0;
        }
    }
    
}