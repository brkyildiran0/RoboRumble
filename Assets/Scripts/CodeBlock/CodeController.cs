using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeController : MonoBehaviour
{
    [SerializeField] private List<Execute> startingBlocks;
    [SerializeField] private List<Entity> startingEntities;
    [SerializeField] private List<int> startingPositions;
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
            TileController.Instance.AssignEntityToTile(startingPositions[2 * i] , startingPositions[2 * i + 1], startingEntities[i]);
            startingEntities[i].GetCollisionController().SetIsCollidable(true);
            startingEntities[i].transform.position = TileController.Instance.GetTile(startingPositions[2 * i], startingPositions[2 * i + 1]).transform.position;
        }
    }


}
