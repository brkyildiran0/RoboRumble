using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TickCounter : MonoBehaviour
{
    public float tickInterval;

    public static TickCounter Instance;
    
    private void Awake()
    {
        Instance = this;
        EventManager.OnTilesCreated += StartTickCounter;
    }

    private void StartTickCounter()
    {
        StartCoroutine(TickCount());
    }

    private IEnumerator TickCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickInterval);
            EventManager.TriggerOnTick();
        }
    }
}
