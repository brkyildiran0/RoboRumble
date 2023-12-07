using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TickCounter : MonoBehaviour
{
    [SerializeField] private float tickInterval;
    

    private float timePassedAfterTick;


    private void Update()
    {
        timePassedAfterTick += Time.deltaTime;

        if (timePassedAfterTick > tickInterval)
        {
            EventManager.TriggerOnTick();
            timePassedAfterTick = 0;
        }
    }
}
