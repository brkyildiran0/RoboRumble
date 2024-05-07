using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CodeController : MonoBehaviour
{
    public static CodeController Instance;
    //[SerializeField] private List<Execute> startingBlocks;
    public List<GameObject> startingBlocks;
    //[SerializeField] private List<Entity> startingEntities;
    public List<GameObject> startingEntities;
    [SerializeField] private List<int> startingPositions;

    public GameObject entityText;
    //private List<GameObject> entities;

    //public List<GameObject> startingObjects;
    //public GameObject startBlock;
    //public Transform CloneBlocksInto;
    
    public int level = 1;
    
    private void Awake()
    {
        Instance = this;
        EventManager.OnTilesCreated += SetTileEntities;

        SetEntities();

        for (int i = 0; i < startingBlocks.Count; i++)
        {
            Debug.Log("setting blocksasd");
            startingBlocks[i].GetComponent<Execute>().SubsribeToTick();

            if (i != 0)
            {
                startingBlocks[i].SetActive(false);
            }
        }
    }

    private void SetTileEntities()
    {
        /*for (int i = 0; i < startingEntities.Count; i++)
        {
            GameObject temp = GameObject.Instantiate(startBlock, new Vector3(1360.1f, 926.5f, 0f), Quaternion.identity);
            startingObjects.Add(temp);
            temp.name = "G" + i + " While Game Is Running";
            temp.transform.parent = CloneBlocksInto;
            startingBlocks.Add(temp.GetComponent<Execute>());
        }*/

        for (int i = 0; i < startingBlocks.Count; i++)
        {
            TileController.Instance.AssignEntityToTile(startingPositions[2 * i], startingPositions[2 * i + 1], startingEntities[i].GetComponent<Entity>());
            startingEntities[i].GetComponent<Entity>().GetCollisionController().SetIsCollidable(true);
            startingEntities[i].GetComponent<Entity>().transform.position = TileController.Instance.GetTile(startingPositions[2 * i], startingPositions[2 * i + 1]).transform.position;
        }

    }

    private void SetEntities()
    {

        for (int i = 0; i < startingBlocks.Count; i++)
        {
            startingBlocks[i].GetComponent<Execute>().SetEntity(startingEntities[i].GetComponent<Entity>());
            if (i == 0) { startingEntities[i].GetComponent<Entity>().setSelected(true);}
        }

        /*for (int i = 0; i < startingBlocks.Count; i++)
        {
            startingBlocks[i].GetComponent<Execute>().SetEntity(startingEntities[i]);
        }*/



        /*for (int i = 0; i < startingBlocks.Count; i++)
        {
            
            if (startingBlocks[i].GetComponent<Execute>().GetEntity() == gameObject.GetComponent<Entity>())
            {
                ObjectOne = startingBlocks[i].GetComponent<Entity>();
            }
        }
        bool currentState = ObjectOne.activeSelf;

        currentState = !currentState;

        ObjectOne.SetActive(currentState);*/
    }

    public Entity GetSelectedEntity()
    {
        foreach (var entity in startingEntities)
        {
            if (entity.GetComponent<Entity>().getSelected())
            {
                return entity.GetComponent<Entity>();
            }
        }

        return startingEntities[0].GetComponent<Entity>();
    }

    private void CheckOnRoute()
    {
        if (TilePanelUI.Instance.PathContains(startingEntities[0].GetComponent<Entity>().GetCurrentTile()) == 0)
        {
            Debug.Log("continue games");
            return;
        }
        if (TilePanelUI.Instance.PathContains(startingEntities[0].GetComponent<Entity>().GetCurrentTile()) == 1)
        {
            EventManager.OnGameOverSuccess();
            return;
        }
        if (TilePanelUI.Instance.PathContains(startingEntities[0].GetComponent<Entity>().GetCurrentTile()) == -1)
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

    private void OnDestroy()
    {
        EventManager.OnTilesCreated -= SetTileEntities;
    }
}
