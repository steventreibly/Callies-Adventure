using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DualGrid.Tiles
{
    [Serializable]
    public class DualGridDataTile : Tile
    {
        private CDualGridTilemap _cDualGridTilemap;

        /// <summary>
        /// Retrieves any tile rendering data from the scripted file
        /// </summary>
        /// <param name="location">Location of the Tile on the Tilemap</param>
        /// <param name="tilemap">The Tilemap the tile is present on</param>
        /// <param name="tileData">Data to render the tile</param>
        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            SetDataTilemap(tilemap);
            
            base.GetTileData(location, tilemap, ref tileData);

            if (_cDualGridTilemap != null && _cDualGridTilemap.GameObjectOrigin != OriginEnum.DataTilemap)
            {
                tileData.gameObject = null;
            }
        }

        private void SetDataTilemap(ITilemap tilemap)
        {
            var originTilemap = tilemap.GetComponent<Tilemap>();
            _cDualGridTilemap = originTilemap.GetComponent<CDualGridTilemap>();
        }
    }
}