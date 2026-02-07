using DualGrid.Tiles;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DualGrid.Runtime.Components
{
    [RequireComponent(typeof(Tilemap))]
    [DisallowMultipleComponent]
/*
 * Converts a Tilemap to a Dual Grid Tilemap.
 * This component only guarantees the continuous update of the render tilemap.
 * Data tilemap changes will be handled separately in an editor script.
 */
    public class CDualGridTilemap : MonoBehaviour
    {
        [field: SerializeField] 
        public DualGridRuleTile RenderTile { get; internal set; }

        public DualGridDataTile DataTile => RenderTile.DataTile;
    
        [field: SerializeField]
        public bool EnableTilemapCollider { get; internal set; }
    
        [field: SerializeField]
        public OriginEnum GameObjectOrigin { get; internal set; }

        [field: SerializeField]
        public Tilemap DataTilemap { get; private set; }
    
        [field: SerializeField]
        public Tilemap RenderTilemap { get; private set; }

        private void OnEnable()
        {
            Tilemap.tilemapTileChanged += HandleTilemapChange;
        }

        /// <summary>
        /// For each update tile in the Data Tilemap update the Render Tilemap
        /// </summary>
        /// <param name="tilemap"></param>
        /// <param name="tileChanges"></param>
        private void HandleTilemapChange(Tilemap tilemap, Tilemap.SyncTile[] tileChanges)
        {
            if (tilemap == DataTilemap)
            {
                if (RenderTile == null)
                {
                    Debug.LogError($"{RenderTile} cannot be updated because tile is not set in dual grid component", RenderTilemap);
                    return;
                }

                foreach (Tilemap.SyncTile tileChange in tileChanges)
                {
                    RefreshRenderTiles(tileChange.position);
                }
            }
        }

        /// <summary>
        ///     Fully refreshes the RenderTilemap by forcing an update from all tiles in the DataTilemap
        /// </summary>
        public virtual void RefreshRenderTilemap()
        {
            if (RenderTile == null)
            {
                Debug.LogError($"Cannot refresh tilemap, because tile is not set in dual grid module", RenderTilemap);
                return;
            }
        
            RenderTilemap.ClearAllTiles();
            foreach (var position in DataTilemap.cellBounds.allPositionsWithin)
            {
                if (DataTilemap.HasTile(position))
                {
                    DataTilemap.SetTile(position, DataTile);
                    RefreshRenderTiles(position);
                }
            }
        }

        public virtual void RefreshRenderTiles(Vector3Int dataTilePosition)
        {
            bool hasDataTile = DataTilemap.HasTile(dataTilePosition);

            foreach (Vector3Int renderTilePosition in DualGridUtils.GetRenderTilePositions(dataTilePosition))
            {
            
            }
        }
    }
}
