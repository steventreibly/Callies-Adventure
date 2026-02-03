namespace DualGrid.Utils
{
    public class DualGridNeighbor
    {
        /// <summary>
        ///     The Dual Grid Rule Tile will check if the contents of the data tile in that direction in filled.
        ///     If not, the rule will fail
        /// </summary>
        public const int Filled = 1;
        
        /// <summary>
        ///     The Dual Grid Rule Tile will check if the contents of the data tile in that direction is not filled
        ///     If it is, the rule will fail.
        /// </summary>
        public const int NotFilled = 2;
    }
}
