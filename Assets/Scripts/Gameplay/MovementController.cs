
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    private bool isMovable = true;

    private float _distanceBetweenTwoTiles = 1f;

    private Movement _currentMovement;

    public bool IsMovable()
    {
        return isMovable;
    }

    public void SetIsMovable(bool isMovable)
    {
        this.isMovable = isMovable;
    }

    public void DisplaceFromCurrentTile(int rowMovement, int columnMovement)
    {
        Debug.Log(_currentMovement.startTile.row);
        Tile endTile = TileController.Instance.GetTile(_currentMovement.startTile.row + rowMovement,
            _currentMovement.startTile.col + columnMovement);
        SetCurrentMovement(new Movement(_currentMovement.startTile, endTile, _currentMovement.entity));
       
        DisplaceToAnotherTile(endTile);
        EventManager.TriggerOnMovement(_currentMovement);
    }

    public void DisplaceToAnotherTile(Tile targetTile)
    {
        transform.DOMove(targetTile.transform.position, 0.5f);
    }

    public void SetCurrentMovement(Movement movement)
    {
        _currentMovement = movement;
    }

}