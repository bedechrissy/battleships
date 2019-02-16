using System;

namespace BattleShips.Helpers
{
    /// <summary>
    /// A very crude helper, unmanaged and untested class for printing ASCII art n' shit
    /// </summary>
    public class AsciiHelper
    {
        /// <summary>
        /// Prints a Battle Boat
        /// </summary>
        public static void DrawBoat()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine();
            Console.WriteLine();

            WriteWhiteSpace(38);
            Console.Write("|__");
            Console.WriteLine();

            WriteWhiteSpace(38);
            Console.Write("|\\/");
            Console.WriteLine();

            WriteWhiteSpace(38);
            Console.Write("---");
            Console.WriteLine();

            WriteWhiteSpace(38);
            Console.Write("/ | [");
            Console.WriteLine();

            WriteWhiteSpace(31);
            Console.Write("!");
            WriteWhiteSpace(6);
            Console.Write("|||");
            Console.WriteLine();

            WriteWhiteSpace(29);
            Console.Write("_/|");
            WriteWhiteSpace(4);
            Console.Write("_/|-++'");
            Console.WriteLine();

            WriteWhiteSpace(25);
            Console.Write("+  +--|--|--|_ |-");
            Console.WriteLine();

            WriteWhiteSpace(22);
            Console.Write("{ /|__|   |/\\__|   |---  |||__/");
            Console.WriteLine();

            WriteWhiteSpace(21);
            Console.Write("+---------------___[}-_===_.'____  ");
            WriteWhiteSpace(15);
            Console.Write("/\\");
            Console.WriteLine();

            WriteWhiteSpace(17);
            Console.Write("____`-' ||___-{]_| _[}-  |     |_[___\\==--");
            WriteWhiteSpace(12);
            Console.Write("\\/");
            WriteWhiteSpace(3);
            Console.Write("_");
            Console.WriteLine();

            WriteWhiteSpace(1);
            Console.Write("__..._____--==/___]_|__|_____________________________[___\\== --____, ------' .7");
            Console.WriteLine();

            WriteWhiteSpace(1);
            Console.WriteLine("\\ BB - 61 /");

            WriteWhiteSpace(2);
            Console.WriteLine("\\_________________________________________________________________________ |");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;

        }

        /// <summary>
        /// Prints the winner medal
        /// </summary>
        public static void DrawWinner()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$\\      $$\\ $$\\ ");
            Console.WriteLine("$$ | $\\  $$ |\\__ |  ");
            Console.WriteLine("$$ |$$$\\ $$ |$$\\ $$$$$$$\\  $$$$$$$\\   $$$$$$\\   $$$$$$\\");
            Console.WriteLine("$$ $$ $$\\$$ |$$ |$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ ");
            Console.WriteLine("$$$$  _$$$$ |$$ |$$ |  $$ |$$ |  $$ |$$$$$$$$ |$$ |  \\__|");
            Console.WriteLine("$$$  / \\$$$ |$$ |$$ |  $$ |$$ |  $$ |$$   ____|$$ |  ");
            Console.WriteLine("$$  /   \\$$ |$$ |$$ |  $$ |$$ |  $$ |\\$$$$$$$\\ $$ | ");
            Console.WriteLine("\\__/     \\__|\\__|\\__|  \\__|\\__|  \\__| \\_______|\\__| ");
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        /// <summary>
        /// Prints the loser Wha Whaa!
        /// </summary>
        public static void DrawYouLose()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine();
            Console.WriteLine(" __     __           _     ");
            Console.WriteLine(" \\ \\   / /          | |  ");
            Console.WriteLine("  \\ \\_/ /__  _   _  | | __");
            Console.WriteLine("   \\   / _ \\| | | | | |/ _ \\/ __|/ _ \\");
            Console.WriteLine("   | | (_) | |_| | | | (_) \\__ \\  __/");
            Console.WriteLine("    |_|\\___/ \\__,_| |_|\\___/|___/\\___|");
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
    }
}
