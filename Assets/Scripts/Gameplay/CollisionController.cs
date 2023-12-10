using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private int collisionRadius;
    private bool isCollidable;

    public int GetCollisionRadius()
    {
        return collisionRadius;
    }

    public bool IsCollidable()
    {
        return isCollidable;
    }

    public void SetIsCollidable(bool isCollidable)
    {
        this.isCollidable = isCollidable;
    }

    public void SetCollisionRadius(int collisionRadius)
    {
        this.collisionRadius = collisionRadius;
    }

    public List<Entity> GetEntitiesWithinCollisonRadius(int row, int column)
    {
        List<Entity> result = new List<Entity>();
        List<Tile> tilesAround = TileController.Instance.GetTilesAroundPoint(row, column, collisionRadius);
        foreach (var tile in tilesAround)
        {
            List<Entity> entitiesOnTile = tile.GetEntitiesOnTile();
            foreach (var entity in entitiesOnTile)
            {
                if (entity.GetCollisionController().IsCollidable())
                {
                    result.Add(entity);
                }
            }
        }
        return result;
    }
}
