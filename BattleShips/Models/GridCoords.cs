using BattleShips.Helpers;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    /// <summary>
    /// The model for Grid Coordinates
    /// </summary>
    public class GridCoords
    {
        /// <summary>
        /// Constructor
        /// Initialises new Grid Coords with the expected parameters
        /// </summary>
        public GridCoords(int x, string y)
        {
            Condition.Requires(x).IsGreaterOrEqual(1);
            Condition.Requires(y).IsNotNullOrWhiteSpace();

            X = x;
            Y = y;
        }

        /// <summary>
        /// The X Coordinate
        /// </summary>
        public int X { get; private set; }
        
        /// <summary>
        /// The Y Coordinate
        /// </summary>
        public string Y { get; private set; }
        
    }
}
