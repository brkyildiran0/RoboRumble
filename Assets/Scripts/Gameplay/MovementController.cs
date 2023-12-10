
using System.Collections;
using System.Collections.Generic;
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
        transform.position += new Vector3(columnMovement,rowMovement, 0) * _distanceBetweenTwoTiles;
        
        Debug.Log(_currentMovement.startTile.row);
        Tile endTile = TileController.Instance.GetTile(_currentMovement.startTile.row + rowMovement,
            _currentMovement.startTile.col + columnMovement);
        SetCurrentMovement(new Movement(_currentMovement.startTile, endTile, _currentMovement.entity));
        
        EventManager.TriggerOnMovement(_currentMovement);
    }

    public void DisplaceToAnotherTile(Tile targetTile)
    {
        transform.position = targetTile.transform.position;
    }

    public void SetCurrentMovement(Movement movement)
    {
        _currentMovement = movement;
    }

}