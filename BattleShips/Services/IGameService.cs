using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    /// <summary>
    /// The interface for the Game Service
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Creates an instance of a game
        /// </summary>
        /// <returns></returns>
        Game CreateGame();

        /// <summary>
        /// Method which handles a shot being fired within a Game
        /// </summary>
        /// <param name="game"></param>
        /// <param name="shot"></param>
        /// <returns></returns>
        Game FireShot(Game game, GridCoords shot);
    }
}
