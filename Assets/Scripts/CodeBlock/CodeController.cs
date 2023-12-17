using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CodeController : MonoBehaviour
{
    [SerializeField] private List<Execute> startingBlocks;
    [SerializeField] private List<Entity> startingEntities;
    [SerializeField] private List<int> startingPositions;
    
    public int level = 1;
    
    private void Awake()
    {
        EventManager.OnTilesCreated += SetTileEntities;

        EventManager.OnPreTick += SetEntities;

        EventManager.OnTick += CheckOnRoute;
        
        for (int i = 0; i < startingBlocks.Count; i++)
        {
            startingBlocks[i].SubsribeToTick();
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

    private void SetEntities()
    {
        for (int i = 0; i < startingBlocks.Count; i++)
        {
            startingBlocks[i].SetEntity(startingEntities[i]);
        }
        
    }

    private void CheckOnRoute()
    {
        if (TilePanelUI.Instance.PathContains(startingEntities[0].GetCurrentTile()) == 0)
        {
            Debug.Log("continue games");
            return;
        }
        if (TilePanelUI.Instance.PathContains(startingEntities[0].GetCurrentTile()) == 1)
        {
            EventManager.OnGameOverSuccess();
            return;
        }
        if (TilePanelUI.Instance.PathContains(startingEntities[0].GetCurrentTile()) == -1)
        {
            EventManager.OnGameOverFailure();
        }
        
         
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("Level " + level );
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level " + level + 1);
    }


}
