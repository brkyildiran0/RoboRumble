using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField] public int rowCount = 0;
    [SerializeField] public int columnCount = 0;
    public Tile[,] tiles;

    public static TileController Instance;

    private void Awake()
    {
        Instance = this;
        tiles = new Tile[rowCount, columnCount];
    }

    void Start()
    {
        InitializeTiles();
    }

    #region Initializers
    public void InitializeTiles()
    {
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
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

    public bool RemoveEntityOnTile(int row, int column, Entity entity)
    {
        if (tiles[row, column].Contains(entity))
        {
            return tiles[row, column].Remove(entity);
        }

        return false;
    }

    public void AssignEntityToTile(int row, int col, Entity entity)
    {
        GetTile(row, col).Assign(entity);
    }

    public List<Tile> GetTilesAroundPoint(int radius, int row, int column)
    {
        List<Tile> result = new List<Tile>();

        for (int currentRow = row - radius; currentRow < row + radius; currentRow++)
        {
            for (int currentColumn = column - radius; currentColumn < columnCount; currentColumn++)
            {
                if (currentRow >= 0 && currentRow < rowCount - 1
                    && currentColumn >= 0 && currentColumn < columnCount - 1)

                {
                    result.Add(GetTile(currentRow, currentColumn));
                }
            }
        }

        return result;
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
