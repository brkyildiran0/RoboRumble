using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField] public int rowCount = 0;
    [SerializeField] public int colCount = 0;

    public Tile[,] tiles;

    void Start()
    {
        InitializeTiles();
    }

    #region Initializers
    public void InitializeTiles()
    {
        tiles = new Tile[rowCount, colCount];

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                tiles[i, j].SetRowColValue(i, j);
            }
        }
    }
    #endregion

    public Tile GetTile(int row, int col)
    {
        return tiles[row, col];
    }

    public bool RemoveEntityAtTile(int row, int col, Entity entity)
    {
        if (tiles[row, col].GetEntitiesOnTile().Contains(entity))
        {
            return tiles[row, col].RemoveEntityOnTile(entity);
        }

        return false;
    }

    //public bool MoveFromTo(int start_row, int start_col, int target_row, int target_col)
    //{
    //    if (tiles[start_row, start_col] != null)
    //    {
    //        if (tiles[target_row, target_col] != null)
    //        {
    //            tiles[target_row, target_col] = tiles[start_row, start_col];
    //            tiles[start_row, start_col] = null;
    //        }
    //    }
    //}
}
