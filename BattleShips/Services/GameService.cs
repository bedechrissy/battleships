using BattleShips.Helpers;
using BattleShips.Models;
using BattleShips.Services;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    /// <summary>
    /// Handles the logic for the actual game
    /// </summary>
    public class GameService : IGameService
    {
        /// <summary>
        /// Creates a game
        /// </summary>
        /// <returns></returns>
        public Game CreateGame()
        {
            var grid = CreateGrid(10, 10);
            grid.CalculateBoatCapacities();

            // Create a collection of Boats
            List<Boat> boats = new List<Boat>();

            // Create the boats
            boats.Add(new Boat("Boaty McBattleship", BoatType.BattleShip, 5));
            boats.Add(new Boat("Dave The Destroyer", BoatType.Destroyer, 4));
            boats.Add(new Boat("Dennis", BoatType.Destroyer, 4));

            // Position the boats
            foreach (Boat boat in boats)
            {
                grid.PositionBoat(boat);
                grid.CalculateBoatCapacities();
            }

            // Create a new game
            var game = new Game(grid, boats, 20, "Player 1");

            return game;
        }

        /// <summary>
        /// Method which handles a shot being fired within a Game
        /// </summary>
        /// <param name="game"></param>
        /// <param name="shot"></param>
        /// <returns></returns>
        public Game FireShot(Game game, GridCoords shot)
        {
            var indices = ArrayMapper.GetArrayIndicesForCoords(shot);

            var target = game.GameGrid.Cells[indices.X, indices.Y];

            switch (target.Status)
            {
                case GridCellStatus.OpenSea:
                    game = ShotMissed(game, indices);
                    break;
                case GridCellStatus.ShipIntact:
                    game = ShotLanded(game, indices);
                    break;
                case GridCellStatus.ShotLanded:
                    AlreadyAttempted(game);
                    break;
                case GridCellStatus.ShotMissed:
                    AlreadyAttempted(game);
                    break;
            };

            return game;
        }


        /// <summary>
        /// Creates the game grid
        /// </summary>
        /// <returns></returns>
        private Grid CreateGrid(int columns, int rows)
        {
            Condition.Requires(columns).IsGreaterOrEqual(1);
            Condition.Requires(rows).IsGreaterOrEqual(1);

            var grid = new Grid(columns, rows);

            return grid;
        }

        /// <summary>
        /// When a shot fired has already been attempted
        /// </summary>
        private void AlreadyAttempted(Game game)
        {
            Console.Clear();
            Visualiser.PrintCurrentGame(game);
            Console.WriteLine();
            Console.WriteLine("'Avast ye! You've already fired ere'");
        }

        /// <summary>
        /// When a shot fired misses
        /// </summary>
        /// <param name="game"></param>
        /// <param name="indices"></param>
        private Game ShotMissed(Game game, Indices indices)
        {
            game.GameGrid.Cells[indices.X, indices.Y].Status = GridCellStatus.ShotMissed;

            // Lose a life
            game.Lives--;

            // Reset Streak
            game.Streak = 0;

            // Deduct from Score
            if(game.Score > 0)
            {
                game.Score = game.Score - 1;
            };

            Console.Clear();
            Visualiser.PrintCurrentGame(game);

            Console.WriteLine();
            Console.WriteLine("'Unlucky Squire! Ya misses.. Try agen'");

            if (game.Lives == 0)
            {
                Console.Clear();
                game.Active = false;
                game.Score = 0;
                AsciiHelper.DrawYouLose();
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadLine();
            }

            return game;
        }

        /// <summary>
        /// When a shot is landed
        /// </summary>
        /// <param name="game"></param>
        /// <param name="indices"></param>
        private Game ShotLanded(Game game, Indices indices)
        {
            // Update cell and beep
            game.GameGrid.Cells[indices.X, indices.Y].Status = GridCellStatus.ShotLanded;
            Console.Beep(432, 750);

            // Incrememnt streak
            game.Streak++;

            // Initialise first points
            if(game.Score == 0)
            {
                game.Score = 1;
            };

            // Update score and apply streak if not negative.
            if (game.Score > 0)
            {
                game.Score = game.Score + (game.Score * game.Streak);
            }
            else
            {
                game.Score = game.Score + game.Score;
            }

            // Incremement the boat hit counter
            var target = game.GameGrid.Cells[indices.X, indices.Y];

            game.Boats
                .First(b => b.Id == target.BoatHeld.Id)
                .Hits++;

            Console.Clear();
            Visualiser.PrintCurrentGame(game);
            Console.WriteLine();

            Console.WriteLine("'Arrrgh you scurvy landlubber!!, You've hit me' boat!'");

            // Get the boat
            var boat = game.Boats
                .First(b => b.Id == target.BoatHeld.Id);

            // Check length vs. hits
            if (boat.Hits == boat.Length)
            {
                game.BoatsSank++;
                Console.Beep(432, 1500);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("'Blimey! Boat down'");
                Console.ForegroundColor = ConsoleColor.Magenta;
            };

            if (game.Boats.Count() == game.BoatsSank)
            {
                Console.Clear();

                // Winner, Winner.
                game.Score = game.Score + (game.Lives * 10);
                game.Active = false;
                AsciiHelper.DrawWinner();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Congratulations, ");
                Console.Write(game.PlayerName);
                Console.Write(", Your Final Score was: ");
                Console.Write(game.Score);
                Console.WriteLine();
                Console.ReadLine();
            };

            return game;
        }
    }
}
