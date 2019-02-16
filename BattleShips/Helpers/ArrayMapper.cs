using BattleShips.Models;
using CuttingEdge.Conditions;
using System;

namespace BattleShips.Helpers
{
    /// <summary>
    /// Assist in the mapping between friendly named coordinates and Grid Array index values 
    /// /// </summary>
    public class ArrayMapper
    {
        /// <summary>
        /// Returns a pair of array indices for a given set of Grid Coordinates
        /// </summary>
        /// <returns></returns>
        public static Indices GetArrayIndicesForCoords(GridCoords coords)
        {
            Condition.Requires(coords).IsNotNull("coords");
            Condition.Requires(coords.X).IsGreaterOrEqual(1);
            Condition.Requires(coords.Y).IsShorterOrEqual(1);

            var x = coords.X - 1;
            var y = AlphabetHelper.GetAlphabetPositionOfLetter(coords.Y.ToString()) - 1;

            var indices = new Indices(x, y);
            return indices;
        }

        /// <summary>
        /// Returns Grid Coordinates from a pair of array indices
        /// </summary>
        /// <returns></returns>
        public static GridCoords GetCoordsForArrayIndices(Indices indices)
        {
            Condition.Requires(indices).IsNotNull();

            var X = indices.X + 1;
            var Y = AlphabetHelper.GetLetterFromAlphabetPosition(indices.Y + 1);

            return new GridCoords(X, Y);
        }
    }
}
