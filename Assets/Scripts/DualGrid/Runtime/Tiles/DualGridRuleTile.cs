using System;
using DualGrid.Utils;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DualGrid.Tiles
{
    [Serializable]
    [CreateAssetMenu(fileName = "DualGridRuleTile", menuName = "Scriptable Objects/DualGridRuleTile")]
    public class DualGridRuleTile : RuleTile<DualGridNeighbor>
    {
        [field: SerializeField, HideInInspector] 
        public Texture2D OriginalTexture { get; internal set; }

        [field: SerializeField, HideInInspector]
        public DualGridDataTile DataTile { get; private set; }
        
        private CDualGridTilemap _cDualGridTilemap;
        
        private Tilemap _dataTilemap;

        /// <summary>
        ///     Sets the actual Data Tilemap before updating the tile
        /// </summary>
        /// <param name="location"></param>
        /// <param name="tilemap"></param>
        /// <param name="tileData"></param>
        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            
        }

        private void SetDataTilemap(ITilemap tilemap)
        {
            var originTilemap = tilemap.GetComponent<Tilemap>();

            _cDualGridTilemap = originTilemap.GetComponentInParent<CDualGridTilemap>();

            if (_cDualGridTilemap != null)
            {
                _dataTilemap = _cDualGridTilemap.DataTilemap;
            }
        }
    }
}
