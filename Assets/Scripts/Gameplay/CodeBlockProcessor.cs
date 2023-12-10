using System;
using UnityEngine;
using UnityEngine.UI;

public class CodeBlockProcessor: MonoBehaviour
{
    private MovementCompiler movementCompiler;

    private void Awake()
    {
        EventManager.OnTick += ProcessOneCycle;
        movementCompiler = new MovementCompiler();

    }

    private void OnDestroy()
    {
        EventManager.OnTick -= ProcessOneCycle;
    }

    private void ProcessOneCycle()
    {
        ProcessMovements();
    }

    private void ProcessMovements()
    {
        movementCompiler.ExecuteMovements();
    }
}