using UnityEngine;

namespace J_Framework
{
    public static class TilePosition2DIntUtils
    {
        public static Vector2Int[] GetTilePositionsByOriginAndSize(Vector2Int origin, Vector2Int size)
        {
            Vector2Int[] positions = new Vector2Int[size.x * size.y];
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    int index = (i * size.x) + j;
                    positions[index] = new Vector2Int(origin.x + j, origin.y + i);
                }
            }

            return positions;
        }

        public static Vector2Int[] GetTilePositionsByMinMax(Vector2Int min, Vector2Int max)
        {
            Vector2Int size = new Vector2Int(max.x - min.x + 1, max.y - min.y + 1);
            Vector2Int[] positions = new Vector2Int[size.x * size.y];
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    int index = (i * size.x) + j;
                    positions[index] = new Vector2Int(min.x + j, min.y + i);
                }
            }
            
            return positions;
        }
    }
}