using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeController : MonoBehaviour
{
    [SerializeField] private List<GameObject> startingBlocks;

    private void Awake()
    {
        foreach (var block in startingBlocks)
        {
            block.GetComponent<Execute>().SubsribeToTick();
        }
    }

}
