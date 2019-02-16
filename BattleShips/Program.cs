using BattleShips.Helpers;
using BattleShips.Models;
using BattleShips.Services;
using Ninject;
using System;
using System.Reflection;

namespace BattleShips
{
    /// <summary>
    /// The main program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point into BattleShips
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Dependency Injection
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var gameService = kernel.Get<IGameService>();

            // Print the splash screen
            PrintSplash();

            // Create a new game instance and set the player name
            var game = gameService.CreateGame();
            game.PlayerName = Visualiser.RequestPlayerName();

            // Print the grid
            Visualiser.PrintCurrentGame(game);

            // Prompt the user for input
            Console.WriteLine();
            Console.WriteLine("Take aim, type in a grid reference e.g C5 and hit Return to fire!");

            // The Game Loop
            do
            {
                var input = Console.ReadLine();
                try
                {
                    var y = input.Substring(0, 1).ToUpper();
                    var x = Convert.ToInt32(input.Substring(1));
                    var shot = new GridCoords(x, y);

                    game = gameService.FireShot(game, shot);
                } catch (Exception)
                {
                    Console.WriteLine("Shot Invalid, Try again");
                }

            } while (game.Active == true);

        }

        /// <summary>
        /// Prints the initial splash screen
        /// </summary>
        private static void PrintSplash()
        {
            Visualiser.WriteTitle();
            AsciiHelper.DrawBoat();
            Console.WriteLine();
            Console.WriteLine("Press Any Key to Start");
            Console.ReadKey();
        }
    }
}
