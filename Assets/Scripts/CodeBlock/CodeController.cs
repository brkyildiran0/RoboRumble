using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeController : MonoBehaviour
{
    [SerializeField] private List<Execute> startingBlocks;
    [SerializeField] private List<Entity> startingEntities;
    private void Awake()
    {
        EventManager.OnTilesCreated += SetTileEntities;
        
        for (int i = 0; i < startingBlocks.Count; i++)
        {
            startingBlocks[i].SubsribeToTick();
            startingBlocks[i].SetEntity(startingEntities[i]);
        }
    }

    private void SetTileEntities()
    {
        for (int i = 0; i < startingBlocks.Count; i++)
        {
            TileController.Instance.AssignEntityToTile(i , i, startingEntities[i]);
            startingEntities[i].transform.position = TileController.Instance.GetTile(i, i).transform.position;
        }
    }


}
