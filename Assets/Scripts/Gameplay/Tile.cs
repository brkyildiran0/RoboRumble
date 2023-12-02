using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<Entity> objectsUnderTile = new List<Entity>();
    private float canvas_x_pos;
    private float canvas_y_pos;
    private int row, col;

    public float Canvas_x_pos { get => canvas_x_pos; set => canvas_x_pos = value; }
    public float Canvas_y_pos { get => canvas_y_pos; set => canvas_y_pos = value; }

    public void SetRowColValue(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public bool Remove(Entity entity)
    {
        return objectsUnderTile.Remove(entity);
    }

    public int GetIndexOfEntity(Entity entity)
    {
        return objectsUnderTile.IndexOf(entity);
    }

    public List<Entity> GetEntitiesOnTile()
    {
        return objectsUnderTile;
    }

    public bool Contains(Entity entity)
    {
        return objectsUnderTile.Contains(entity);
    }

    public void Assign(Entity entity)
    {
        objectsUnderTile.Add(entity);
    }
}
