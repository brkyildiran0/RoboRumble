using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TickCounter : MonoBehaviour
{
    public float tickInterval;

    public static TickCounter Instance;

    private bool isAutomatic = false;
    
    private void Awake()
    {
        Instance = this;
        EventManager.AutomaticTickButtonPressed += StartTickCounter;
        EventManager.ManualTickButtonPressed += TickManual;
    }

    private void TickManual()
    {
        EventManager.OnTick();
    }
    private void StartTickCounter()
    {
        isAutomatic = !isAutomatic;
        if (isAutomatic)
        {
            StartCoroutine(TickCount());
        }
    }

    private IEnumerator TickCount()
    {
        while (isAutomatic)
        {
            yield return new WaitForSeconds(tickInterval / 2);
            EventManager.OnPreTick();
            yield return new WaitForSeconds(tickInterval / 2);
            EventManager.OnTick();
        }
    }
}
