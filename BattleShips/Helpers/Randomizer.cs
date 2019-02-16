using BattleShips.Models;
using CuttingEdge.Conditions;
using System;

namespace BattleShips.Helpers
{
    /// <summary>
    /// Responsible for randomising game choices
    /// </summary>
    public class Randomizer
    {
        /// <summary>
        /// Returns a random alignment
        /// </summary>
        /// <returns></returns>
        public static Alignment SelectRandomAlignment()
        {
            var choice = new Random().Next(0, 2);

            Alignment alignment = (Alignment)choice;

            return alignment;
        }

        /// <summary>
        /// Returns array indices for a random grid cell
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static Indices SelectRandomCell(Grid grid)
        {
            Condition.Requires(grid).IsNotNull();

            var height = grid.Cells.GetLength(0);
            var width = grid.Cells.GetLength(1);

            var x = height - 1;
            var y = width - 1;

            var r = new Random();

            x = r.Next(0, x);
            y = r.Next(0, y);

            return new Indices(x, y);
        }
    }
}
