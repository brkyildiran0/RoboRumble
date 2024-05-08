using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<Entity> objectsUnderTile = new List<Entity>();
    private float canvas_x_pos;
    private float canvas_y_pos;
    public int row, col;

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
        entity.SetCurrentTile(this);

        if (IsVoidTile())
        {
            Debug.Log("Player hit a void tile!");
        }
    }

    private bool IsVoidTile()
    {
        // Implement your logic to determine if this tile is a void tile
        // For example, you might check a specific property of the tile
        // or its position in the game world.
        // Replace the return statement below with your actual logic.
        return false; // Placeholder, replace with actual logic
    }
}
