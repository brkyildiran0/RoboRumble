using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCompiler : MonoBehaviour
{
    private List<Movement> currentMovements;

    private void Awake()
    {
        EventManager.OnMovement += AddMovementToList;
    }

    private void AddMovementToList(Movement movement)
    {
        currentMovements.Add(movement);
    }

    private void ExecuteMovements()
    {
        foreach (var movement in currentMovements)
        {
        }
    }

}