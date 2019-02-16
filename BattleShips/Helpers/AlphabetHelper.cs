using CuttingEdge.Conditions;
using System;

namespace BattleShips.Helpers
{
    /// <summary>
    /// Assists in the conversion between Alphabet characters and their numeric position
    /// </summary>
    public class AlphabetHelper
    {
        /// <summary>
        /// Gets the letter for a given alphabet position
        /// </summary>
        /// <returns></returns>
        public static string GetLetterFromAlphabetPosition(int position)
        {
            Condition.Requires(position).IsGreaterOrEqual(1);
            Condition.Requires(position).IsLessOrEqual(26);

            position += 64;

            var letter = Convert.ToChar(position).ToString();

            return letter;
        }

        /// <summary>
        /// Returns the alphabet position for a letter
        /// </summary>
        /// <returns></returns>
        public static int GetAlphabetPositionOfLetter(string letter)
        {
            Condition.Requires(nameof(letter), letter).IsNotNullOrWhiteSpace();

            char character = Convert.ToChar(letter);

            var index = char.ToUpper(character) - 64;

            return index;
        }
    }
}
