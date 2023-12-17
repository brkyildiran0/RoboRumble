using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action OnTick;
    public static Action<Movement> OnMovement;

    public static Action OnTilesCreated;
    public static Action<Collision> OnCollision;

    public static Action ManualTickButtonPressed;
    public static Action ResetButtonPressed;
    public static Action AutomaticTickButtonPressed;

    public static Action OnPreTick;







}