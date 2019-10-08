using System;

namespace Engine
{
    public static class ConsoleWriter
    {
        public static void Write(string text)
        {
            Console.SetCursorPosition(2, Console.CursorTop + 1);
            Console.WriteLine(text);
        }

        public static void WriteLineCenter(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }

        /*public static void WriteLineCenter(string text, Color color)
        {
            Console.BackgroundColor = color.BackColor;
            Console.ForegroundColor = color.ForeColor;
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }*/

        public static void WriteLineBottomCenter(string text)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowTop + Console.WindowHeight - 3;

            WriteLineCenter(text);

            Console.SetCursorPosition(x, y);
        }
    }
}
