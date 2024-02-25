using Gameplay;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Utility
    {
        public static Vector2Int DirectionToVector(Direction direction)
        {
            switch (direction)
            {
                case (Direction.Down):
                    return Vector2Int.down;
                case (Direction.Left):
                    return Vector2Int.left;
                case (Direction.Right):
                    return Vector2Int.right;
                case (Direction.Up):
                    return Vector2Int.up;
                default:
                    return Vector2Int.down;
            }
        }

        public static Direction GetOppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case (Direction.Up):
                    return Direction.Down;
                case (Direction.Down):
                    return Direction.Up;
                case (Direction.Right):
                    return Direction.Left;
                case (Direction.Left):
                    return Direction.Right;
                default:
                    return Direction.Down;
            }
        }

        public static Direction GetDirectionBetweenTiles(Vector2Int startingTile, Vector2Int endingTile)
        {
            var displacement = endingTile - startingTile;
            if (displacement.x > 0)
            {
                return Direction.Right;
            }
            
            if (displacement.x < 0)
            {
                return Direction.Left;
            }
            
            if (displacement.y > 0)
            {
                return Direction.Up;
            }

            if (displacement.y < 0)
            {
                return Direction.Down;
            }

            return Direction.Right;
        }

        public static Vector3Int Vector2IntToVector3Int(Vector2Int vector2)
        {
            Vector3Int vector3 = new Vector3Int(vector2.x, vector2.y, 0);
            return vector3;
        }
        
        public static Vector2Int Vector3IntToVector2Int(Vector3Int vector3)
        {
            Vector2Int vector2 = new Vector2Int(vector3.x, vector3.y);
            return vector2;
        }
    }
}
