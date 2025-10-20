using UnityEngine;
using UnityEngine.Tilemaps;

namespace Game.GridSystem
{
    [CreateAssetMenu(menuName = "Data/Tile")]
    public partial class TileData : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Tile _tile;

        public string Id => _id;
        public Tile Tile => _tile;
    }
}
