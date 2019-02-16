using CuttingEdge.Conditions;

namespace BattleShips.Models
{
    /// <summary>
    /// A class for array indices
    /// </summary>
    public class Indices
    {
        /// <summary>
        /// Constructor
        /// Initialises new Grid Coords with the expected parameters
        /// </summary>
        public Indices(int x, int y)
        {
            Condition.Requires(x).IsGreaterOrEqual(0);
            Condition.Requires(y).IsGreaterOrEqual(0);

            X = x;
            Y = y;
        }

        /// <summary>
        /// x index
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// index
        /// </summary>
       public int Y { get; protected set; }
    }
}
