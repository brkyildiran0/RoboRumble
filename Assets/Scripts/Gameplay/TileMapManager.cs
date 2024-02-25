using System;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultNamespace;
using Gameplay;
using UnityEngine;
using UnityEngine.Tilemaps;
using Debug = UnityEngine.Debug;

public class TileMapManager : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase obtacleTile;
    public TileBase colorableTile;
    public static TileMapManager Instance;

    private const int MaxTileCheckDistance = 100;

    private void Awake()
    {
        Instance = this;
    }

    public Vector2Int GetNextTileInDirection(Vector2Int currentTile, Direction direction)
    {
        var directionVector = Utility.DirectionToVector(direction);
        return currentTile + directionVector;
    }

    public Vector2 TileMapPosToWorldPos(Vector2Int tilePos)
    {
        return tileMap.CellToWorld(Utility.Vector2IntToVector3Int(tilePos));
    }

    public Vector2Int WorldPosToTileMapPos(Vector2 position)
    {
        return Utility.Vector3IntToVector2Int(tileMap.WorldToCell(position));
    }

    public bool HasObstacleOnTilePos(Vector2Int tilePos)
    {
        return tileMap.GetTile(Utility.Vector2IntToVector3Int(tilePos)) == obtacleTile;
    }

    public int GetDistanceBetweenTiles(Vector2Int tile1, Vector2Int tile2)
    {
        var distance = (int) (tile1 - tile2).magnitude;
        return distance;
    }

    public Color GetTileColor(Vector2Int tilePos)
    {
        return tileMap.GetColor(Utility.Vector2IntToVector3Int(tilePos));
    }

    public void SetTileColor(Vector2Int tilePos, Color newColor)
    {
        var vector3 = Utility.Vector2IntToVector3Int(tilePos);
        tileMap.SetTileFlags(vector3, TileFlags.None);
        // tileMap.RefreshTile(tilePos);
        tileMap.SetColor(vector3, newColor);
    }

    public List<Vector2Int> GetPositionsBetweenTiles(Vector2Int startingTile, Vector2Int endingTile)
    {
        List<Vector2Int> positions = new List<Vector2Int> { startingTile };

        var direction = Utility.GetDirectionBetweenTiles(startingTile, endingTile);
        var directionVector = Utility.DirectionToVector(direction);
        var distance = GetDistanceBetweenTiles(startingTile, endingTile);

        for (var i = 0; i < distance; i++)
        {
            var currentTile = startingTile + i * directionVector;
            positions.Add(currentTile);
        }
        
        positions.Add(endingTile);
        
        return positions;
    }


    
}
