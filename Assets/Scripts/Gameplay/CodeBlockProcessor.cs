using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CodeBlockProcessor: MonoBehaviour
{
    private MovementCompiler movementCompiler;
    private CollisionCompiler collisionCompiler;

    private float delay = 0.3f;

    private void Awake()
    {
        EventManager.OnTick += ProcessOneCycle;
        movementCompiler = new MovementCompiler();
        collisionCompiler = new CollisionCompiler();

    }

    private void OnDestroy()
    {
        EventManager.OnTick -= ProcessOneCycle;
    }

    private void ProcessOneCycle()
    {
        StartCoroutine(PipeLine());
    }

    private IEnumerator PipeLine()
    {
        // collisionCompiler.ExecuteCollisions();
        yield return new WaitForSeconds(delay);
        movementCompiler.ExecuteMovements();
        
    }

}