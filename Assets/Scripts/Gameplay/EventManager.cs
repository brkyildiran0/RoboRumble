using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnTick;
    public static Action<Movement> OnMovement;

    public EventManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void TriggerOnTick()
    {
        OnTick();
    }

    public void TriggerOnMovement(Movement movement)
    {
        OnMovement(movement);
    }


}