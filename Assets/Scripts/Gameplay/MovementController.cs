
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private bool isMovable = true;

    private float _distanceBetweenTwoTiles = 1f;

    private Movement _currentMovement;

    private Movement _previousMovement;

    public bool IsMovable()
    {
        return isMovable;
    }

    public void SetIsMovable(bool isMovable)
    {
        this.isMovable = isMovable;
    }

    public void DisplaceFromCurrentTileHorizontally(int columnMovement)
    {
        int change = Math.Sign(columnMovement);
        columnMovement = Math.Abs(columnMovement);
        for (int i = 0; i < columnMovement; i++)
        {
            Debug.Log(_currentMovement.startTile.row);
            Tile endTile = TileController.Instance.GetTile(_currentMovement.startTile.row,
                _currentMovement.startTile.col + change);
            SetCurrentMovement(new Movement(_currentMovement.startTile, endTile, _currentMovement.entity));
       
            DisplaceToAnotherTile(endTile);
            EventManager.TriggerOnMovement(_currentMovement);

        }
    }
    public void DisplaceFromCurrentTileVertically(int rowMovement)
    {
        int change = Math.Sign(rowMovement);
        rowMovement = Math.Abs(rowMovement);
        
        for (int i = 0; i < rowMovement; i++)
        {
            Debug.Log(_currentMovement.startTile.row);
            Tile endTile = TileController.Instance.GetTile(_currentMovement.startTile.row + change,
                _currentMovement.startTile.col);
            SetCurrentMovement(new Movement(_currentMovement.startTile, endTile, _currentMovement.entity));
       
            DisplaceToAnotherTile(endTile);
            EventManager.TriggerOnMovement(_currentMovement);

        }
    }


    public void DisplaceToAnotherTile(Tile targetTile)
    {
        transform.DOMove(targetTile.transform.position, TickCounter.Instance.tickInterval);
    }

    public void SetCurrentMovement(Movement movement)
    {
        _currentMovement = movement;
    }

    public Movement GetPreviousMovement()
    {
        return _previousMovement;
    }

}