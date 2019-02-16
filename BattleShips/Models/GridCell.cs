using BattleShips.Helpers;
using CuttingEdge.Conditions;

namespace BattleShips.Models
{
    /// <summary>
    /// The model for a Grid Cell
    /// </summary>
    public class GridCell
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// Initialises a new Grid Cell with the expected parameters
        /// </summary>
        /// <param name="xref"></param>
        /// <param name="yref"></param>
        /// <param name="status"></param>
        public GridCell(int xref, string yref, GridCellStatus status)
        {
            Condition.Requires(xref).IsGreaterOrEqual(1);
            Condition.Requires(AlphabetHelper.GetAlphabetPositionOfLetter(yref)).IsGreaterOrEqual(1);

            XRef = xref;
            YRef = yref;
            Status = status;
            HorizontalBoatCapacity = 0;
            VerticalBoatCapacity = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The X Coordinate of the Grid Cell
        /// </summary>
        public int XRef { get; set; }

        /// <summary>
        /// The Y Coordinate of the Grid Cell
        /// </summary>
        public string YRef { get; set; }

        /// <summary>
        /// The Status of the Grid Cell
        /// </summary>
        public GridCellStatus Status { get; set;  }

        /// <summary>
        /// The max size boat that can be started from this Grid Cell rightwards ->
        /// </summary>
        public int HorizontalBoatCapacity { get; set; }

        /// <summary>
        /// The max size boat that can be started from this Grid Cell downwards !
        /// </summary>
        public int VerticalBoatCapacity { get; set; }

        /// <summary>
        /// The boat the cell is currently holding
        /// </summary>
        public Boat BoatHeld { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calculates the max size boat that can be started vertically from this Grid Cell
        /// </summary>
        public void CalculateVerticalBoatCapacity(Grid grid)
        {
            // Get the array indices for the current Grid Cell
            var gridRef = new GridCoords(XRef, YRef);
            var indices = ArrayMapper.GetArrayIndicesForCoords(gridRef);
            var x = indices.X;
            var y = indices.Y;

            // Get the height of the grid
            var height = grid.Cells.GetLength(0);

            // Reset
            VerticalBoatCapacity = 0;

            // Calculate
            for (int i = x; i < height; i++)
            {
                if (grid.Cells[x, i].Status == GridCellStatus.OpenSea)
                {
                    VerticalBoatCapacity++;
                }
                else
                {
                    VerticalBoatCapacity = 0;
                    break;
                }
            }
        }

        /// <summary>
        /// Calculates the max size boat that can be started Horizontally from this Grid Cell
        /// </summary>
        public void CalculateHorizontalBoatCapacity(Grid grid)
        {
            // Get the array indices for the current Grid Cell
            var gridRef = new GridCoords(XRef, YRef);
            var indices = ArrayMapper.GetArrayIndicesForCoords(gridRef);
            var x = indices.X;
            var y = indices.Y;

            // Get the height of the grid
            var width = grid.Cells.GetLength(1);

            // Reset
            HorizontalBoatCapacity = 0;

            // Calculate
            for (int i = y; i < width; i++)
            {
                if (grid.Cells[x, i].Status == GridCellStatus.OpenSea)
                {
                    HorizontalBoatCapacity++;
                }
                else
                {
                    HorizontalBoatCapacity = 0;
                    break;
                }
            }
        }

        #endregion
    }
}
