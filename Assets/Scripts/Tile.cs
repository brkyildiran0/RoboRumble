using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<Entity> objectsUnderTile = new List<Entity>();
    private int row, col;

    public void SetRowColValue(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public bool RemoveEntityOnTile(Entity entity)
    {
        return objectsUnderTile.Remove(entity);
    }

    public Entity GetEntityOnTile(Entity entity)
    {
        if (objectsUnderTile.Contains(entity))
        {
            return objectsUnderTile.Find(x => x == entity);
        }
        return null;
    }

    public int GetEntityIndexOnTile(Entity entity)
    {
        if (objectsUnderTile.Contains(entity))
        {
            return objectsUnderTile.FindIndex(x => x == entity);
        }
        return -1;
    }

    public List<Entity> GetEntitiesOnTile()
    {
        return objectsUnderTile;
    }
}
