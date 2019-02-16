using BattleShips.Models;
using CuttingEdge.Conditions;
using System;

namespace BattleShips.Helpers
{
    /// <summary>
    /// A crude and untested  halper to visualise the game, (the UI!)
    /// </summary>
    public class Visualiser
    {

        /// <summary>
        /// Write the title
        /// </summary>
        public static void WriteTitle()
        {
            Console.WriteLine();
            WriteWhiteSpace(30);
            Console.WriteLine("Welcome to BattleBoats©");
        }

        /// <summary>
        /// A method which prints the current grid
        /// </summary>
        /// <param name="grid"></param>
        public static void PrintCurrentGame(Game game)
        {
            Condition.Requires(game).IsNotNull();

            Console.Clear();

            // Write the Game Stats Header
            WriteGameStats(game);
            var grid = game.GameGrid;

            // Write the Grid Refs for the Y Axis
            WriteYRefHeader(game.GameGrid);

            // Write Grid
            for (int x = 0; x < grid.Cells.GetLength(0); x++)
            {
                // Write Grid Cell Lines
                for (int y = 0; y < grid.Cells.GetLength(0); y++)
                {
                    Console.Write("  __");
                }
                Console.WriteLine();

                // Write Grid Cell Content
                for (int y = 0; y < grid.Cells.GetLength(1); y++)
                {
                    Console.Write("|");
                    var cell = grid.Cells[x, y];

                    switch (cell.Status)
                    {
                        case GridCellStatus.OpenSea:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write( " ~ ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case GridCellStatus.ShipIntact:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" ~ ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case GridCellStatus.ShotLanded:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" X ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case GridCellStatus.ShotMissed:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" 0 ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        default:
                            Console.Write(" ");
                            break;
                    }
                }

                // Write Grid XRef content for each row
                Console.Write("|");
                Console.Write("  ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(grid.Cells[x, 0].XRef);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Requests a player name
        /// </summary>
        /// <returns></returns>
        public static string RequestPlayerName()
        {
            Console.Clear();
            Console.WriteLine("Please enter your name, and press enter: ");

            var playerName = Console.ReadLine();

            return playerName;
        }

        #region Private Methods

        /// <summary>
        /// Writes the game statistics header
        /// </summary>
        /// <param name="game"></param>
        private static void WriteGameStats(Game game)
        {
            // Write Score / Lives data
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(game.PlayerName);
            if (game.Lives <= 10) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
            if (game.Lives <= 5) { Console.ForegroundColor = ConsoleColor.Red; }
            Console.Write("Lives Remaining: ");
            Console.Write(game.Lives);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Score: ");
            if (game.Score > 100) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            Console.Write(game.Score);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        /// <summary>
        /// Writes the Grid References for the X Axis
        /// </summary>
        /// <param name="grid"></param>
        private static void WriteYRefHeader(Grid grid)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            // Write Y CoOrd Grid Refs
            for (int y = 0; y < grid.Cells.GetLength(0); y++)
            {
                Console.Write("  ");
                Console.Write(grid.Cells[0, y].YRef);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        /// <summary>
        /// Writes whitespace of a specific length to the console
        /// </summary>
        /// <param name="length"></param>
        private static void WriteWhiteSpace(int length)
        {
            for (int x = 0; x <= length; x++)
            {
                Console.Write(" ");
            }
        }

        #endregion
    }
}
