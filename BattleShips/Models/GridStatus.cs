namespace BattleShips.Models
{
    /// <summary>
    /// The defined Grid Cell status'
    /// </summary>
    public enum GridCellStatus : int
    {
        /// <summary>
        /// The calm and Open Sea, the default Grid Cell Status
        /// </summary>
         OpenSea = 0,

         /// <summary>
         /// Ship in this location, shots not yet fired
         /// </summary>
         ShipIntact = 1,

         /// <summary>
         /// Unlucky San
         /// </summary>
         ShotMissed = 2,

         /// <summary>
         /// Ouch (For you)
         /// </summary>
         ShotLanded = 3
    }
}
