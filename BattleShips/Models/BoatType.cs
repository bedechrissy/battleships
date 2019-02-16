namespace BattleShips.Models
{
    /// <summary>
    /// The defined Boat Types
    /// </summary>
    public enum BoatType : int
    {
        /// <summary>
        /// The mother of all
        /// </summary>
        AircraftCarrier = 0,

        /// <summary>
        /// Battleship
        /// </summary>
        BattleShip = 1,

        /// <summary>
        /// Cruiser
        /// </summary>,
        Cruiser = 2,

        /// <summary>
        /// Destroyer
        /// </summary>,
        Destroyer = 3,

        /// <summary>
        /// Patrol Boat
        /// </summary>,
        PatrolBoat = 4,

        /// <summary>
        /// Submarine
        /// </summary>
        Submarine = 5,

        /// <summary>
        /// UBoat
        /// </summary>
        UBoat = 6

    }
}
