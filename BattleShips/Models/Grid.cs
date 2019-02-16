using BattleShips.Helpers;
using CuttingEdge.Conditions;
using System;

namespace BattleShips.Models
{
    /// <summary>
    /// The model for a Grid
    /// </summary>
    public class Grid
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// Initialises a new Grid with the expected parameters and sets up Grid Cells with references
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        public Grid(int columns, int rows)
        {
            Condition.Requires(columns);
            Condition.Requires(rows);

            Cells = new GridCell[columns, rows];

            for (int c = 0; c < columns; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    var xref = c + 1; // Not zero indexed
                    var yref = AlphabetHelper.GetLetterFromAlphabetPosition(r + 1).ToString();
                    var status = GridCellStatus.OpenSea;

                    Cells[c, r] = new GridCell(xref, yref, status);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The celled surface area of the Grid
        /// </summary>
        public GridCell[,] Cells { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculate the boat capacaities
        /// </summary>
        public void CalculateBoatCapacities()
        {
            foreach (GridCell cell in Cells)
            {
                cell.CalculateVerticalBoatCapacity(this);
                cell.CalculateHorizontalBoatCapacity(this);
            }
        }

        /// <summary>
        /// Positions the boat on the grid.
        /// </summary>
        public void PositionBoat(Boat boat)
        {
            var alignment = Randomizer.SelectRandomAlignment();

            var positioned = false;

            do
            {
                var indices = Randomizer.SelectRandomCell(this);

                if (alignment == Alignment.Horizontal
                     && Cells[indices.X, indices.Y].HorizontalBoatCapacity >= boat.Length)
                {
                    PlaceBoat(boat, indices, alignment);
                    positioned = true;
                }
                else if (alignment == Alignment.Vertical
                      && Cells[indices.X, indices.Y].VerticalBoatCapacity >= boat.Length)
                {
                    PlaceBoat(boat, indices, alignment);
                    positioned = true;
                }
            } while (positioned == false);
        }

        /// <summary>
        ///  The placement of the boat
        /// </summary>
        /// <param name="boat"></param>
        /// <param name=""></param>
        private void PlaceBoat(Boat boat, Indices indices, Alignment alignment)
        {
            var x = indices.X;
            var y = indices.Y;

            for (int i = 1; i <= boat.Length; i++)
            {
                Cells[x, y].Status = GridCellStatus.ShipIntact;
                Cells[x, y].BoatHeld = boat;

                if(alignment == Alignment.Horizontal)
                {
                    y++;
                }
                else if(alignment == Alignment.Vertical)
                {
                    x++;
                }
            }
        }

        #endregion
    }
}
