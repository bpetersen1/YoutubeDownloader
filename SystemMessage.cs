using System;

namespace YouTube_Downloader
{
    public static class SystemMessage
    {
        /// <summary>
        ///     Displays a message on the console with color. You could also pause or pause and exit the application
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="color">ColorEnum</param>
        /// <param name="pause">bool</param>
        /// <param name="pauseAndExit">bool</param>
        public static void WriteConsoleMessage(string message, ColorEnum color, bool pause, bool pauseAndExit)
        {
            Console.ForegroundColor = GetColor(color);

            Console.WriteLine(message);

            Console.ResetColor();

            if (pause) Console.ReadKey();

            if (pauseAndExit)
            {
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private static ConsoleColor GetColor(ColorEnum color)
        {
            switch (color)
            {
                case ColorEnum.Red:
                    return ConsoleColor.Red;

                case ColorEnum.Yellow:
                    return ConsoleColor.Yellow;

                case ColorEnum.Green:
                    return ConsoleColor.Green;

                default:
                    return ConsoleColor.White;
            }
        }
    }
}