using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    [SerializeField] private float tickInterval;

    private float tickCounter;

    private Action OnTick;


    void Update()
    {
        if (ShouldTick())
        {
            OnTick();
        }
    }



    private bool ShouldTick()
    {
        tickCounter += Time.deltaTime;

        if (tickCounter >= tickInterval)
        {
            tickCounter = 0;
            return true;
        }

        return false;
    }
}
