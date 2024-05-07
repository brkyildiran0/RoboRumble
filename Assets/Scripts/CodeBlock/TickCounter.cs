using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class TickCounter : MonoBehaviour
{
    public float tickInterval;

    public static TickCounter Instance;
    public Sequence sequence;

    private bool isAutomatic = false;
    
    private void Awake()
    {
        isAutomatic = false;
        Instance = this;
        EventManager.AutomaticTickButtonPressed += StartTickCounter;
        EventManager.ManualTickButtonPressed += TickManual;
    }
    
    private void OnDestroy()
    {
        EventManager.AutomaticTickButtonPressed -= StartTickCounter;
        EventManager.ManualTickButtonPressed -= TickManual;
        sequence?.Kill();
    }

    private void TickManual()
    {
        EventManager.OnTick();
    }
    private void StartTickCounter()
    {
        Debug.Log("pressed");
        sequence?.Kill();
        isAutomatic = !isAutomatic;
        if (isAutomatic)
        {
            Debug.Log("start tick counter");
            sequence = DOTween.Sequence();
            sequence.AppendInterval(tickInterval / 2f);
            sequence.AppendCallback(() =>
            {
                Debug.Log("tick");
                EventManager.OnTick();
            });
            sequence.SetLoops(-1);
        }
    }

}
