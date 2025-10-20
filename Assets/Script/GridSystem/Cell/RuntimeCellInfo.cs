using System;
using UnityEngine;

namespace Game.GridSystem
{
    public class RuntimeCellInfo
    {
        public string TileId { get; }
        public Vector2Int Position { get; }

        public RuntimeCellInfo(string tileId, Vector2Int position)
        {
            TileId = tileId;
            Position = position;
        }
    }
}