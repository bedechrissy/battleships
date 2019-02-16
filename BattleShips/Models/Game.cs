using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    /// <summary>
    /// The model for a Game
    /// </summary>
    public class Game
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// Initialises a new Game with the expected parameters
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="boats"></param>
        /// <param name="lives"></param>
        /// <param name="playerName"></param>
        public Game(Grid grid, IEnumerable<Boat> boats, int lives, string playerName)
        {
            Condition.Requires(grid).IsNotNull();
            Condition.Requires(boats).IsNotEmpty();
            Condition.Requires(lives).IsGreaterOrEqual(1);
            Condition.Requires(playerName).IsNotNullOrWhiteSpace();

            Active = true;
            Boats = boats;
            GameGrid = grid;
            Lives = lives;
            PlayerName = playerName;
            BoatsSank = 0;
            Streak = 0;
            Score = 0;
        }

        #endregion

        /// <summary>
        /// The status of the game
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// The number of sank boats
        /// </summary>
        public int BoatsSank { get; set; }

        /// <summary>
        /// The game grid
        /// </summary>
        public IEnumerable<Boat> Boats { get; set; }

        /// <summary>
        /// The game grid
        /// </summary>
        public Grid GameGrid { get; set; }

        /// <summary>
        /// The number of lives remaining
        /// </summary>
        public int Lives { get; set; }

        /// <summary>
        /// The name of the player
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Hit streak
        /// </summary>
        public int Streak { get; set; }

        /// <summary>
        /// Game score
        /// </summary>
        public int Score { get; set; }
    }
}
