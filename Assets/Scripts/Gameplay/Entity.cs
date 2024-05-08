

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    private Tile currentTile;
    private MovementController movementController;
    private CollisionController collisionController;
    public bool isSelected;

    private int i;
    

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
        collisionController = GetComponent<CollisionController>();
        movementController.SetCurrentMovement(new Movement(null, null, this));
        isSelected = false;
    }

    public Tile GetCurrentTile()
    {
        return currentTile;
    }

    public bool getSelected()
    {
        return isSelected;
    }

    public void setSelected(bool selected)
    {
        if (selected == true)
        {
            gameObject.GetComponent<Image>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
        } else
        {
            gameObject.GetComponent<Image>().enabled = true;
            gameObject.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        isSelected = selected;
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
            case(Condition.SymbolType.i):
                return i;
            default:
                return 0;
        }
    }

    public void SetValue(Condition.SymbolType symbolType, int value)
    {
        switch (symbolType)
        {
            case (Condition.SymbolType.i):
                i = value;
                break;
        }
    }
    
}