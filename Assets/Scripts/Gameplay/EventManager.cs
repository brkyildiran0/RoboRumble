using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action OnTick;
    public static Action<Movement> OnMovement;

    public static Action OnTilesCreated;

    public static void TriggerOnTick()
    {
        OnTick();
    }

    public static void TriggerOnMovement(Movement movement)
    {
        OnMovement(movement);
    }

    public static void TriggerOnTilesCreated()
    {
        OnTilesCreated();
    }


}