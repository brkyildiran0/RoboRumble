
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
        AudioManager.Instance.PlaySFX("PlayerMove");
        int change = Math.Sign(columnMovement);
        columnMovement = Math.Abs(columnMovement);
        Tile endTile = null;
        DoRotate(true, change == 1); 
        for (int i = 0; i < columnMovement; i++)
        {
            endTile = TileController.Instance.GetTile(_currentMovement.startTile.row,
                _currentMovement.startTile.col + change);
            SetCurrentMovement(new Movement(_currentMovement.startTile, endTile, _currentMovement.entity));
       
            EventManager.OnMovement(_currentMovement);
            
            SetCurrentMovement(new Movement(endTile, null, _currentMovement.entity));

        }
    }
    public void DisplaceFromCurrentTileVertically(int rowMovement)
    {
        AudioManager.Instance.PlaySFX("PlayerMove");
        int change = Math.Sign(rowMovement);
        rowMovement = Math.Abs(rowMovement);
        Tile endTile = null;
        DoRotate(false, change == 1); 
        for (int i = 0; i < rowMovement; i++)
        {
            endTile = TileController.Instance.GetTile(_currentMovement.startTile.row + change,
                _currentMovement.startTile.col);
            SetCurrentMovement(new Movement(_currentMovement.startTile, endTile, _currentMovement.entity));
      
            Debug.Log("endtile: " + endTile);
            EventManager.OnMovement(_currentMovement);
            
            SetCurrentMovement(new Movement(endTile, null, _currentMovement.entity));

        }
    }


    public void DisplaceToAnotherTile(Tile targetTile)
    {
        transform.DOMove(targetTile.transform.position, TickCounter.Instance.tickInterval);
    }

    private void DoRotate(bool isHorizontalMovement, bool isPositive)
    {
        if (isHorizontalMovement)
        {
            if (isPositive)
            {
                transform.DORotate(new Vector3(0, 0, -90), TickCounter.Instance.tickInterval / 4);
                return;
            }
                transform.DORotate(new Vector3(0, 0, 90), TickCounter.Instance.tickInterval / 4);
        }
        else
        {
            if (isPositive)
            {
                transform.DORotate(new Vector3(0, 0, 0), TickCounter.Instance.tickInterval / 4);
                return;
            }
                transform.DORotate(new Vector3(0, 0, -180), TickCounter.Instance.tickInterval / 4);
        }
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