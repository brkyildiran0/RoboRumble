
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Tile currentTile;
    [SerializeField] private MovementController _movementController;
    [SerializeField] private CollisionController _collisionController;

    public bool IsCollidable()
    {
        return _collisionController.IsCollidable();
        
    }

    public bool IsMovable()
    {
        return _movementController.IsMovable();
    }

    public Tile GetCurrentTile()
    {
        return currentTile;
    }

}