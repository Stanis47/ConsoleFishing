using System;

namespace Engine.Menu
{
    public class ConsoleMenuPainter
    {
        readonly Menu menu;

        public ConsoleMenuPainter(Menu menu)
        {
            this.menu = menu;
        }

        public void Paint(int x, int y)
        {
            for (int i = 0; i < menu.Options.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);

                var foreColor = menu.SelectedIndex == i ? ConsoleColor.Black : menu.Options[i].ItemColor.ForeColor;
                var backColor = menu.SelectedIndex == i ? ConsoleColor.White : menu.Options[i].ItemColor.BackColor;

                Console.ForegroundColor = foreColor;
                Console.BackgroundColor = backColor;

                ConsoleWriter.WriteLineCenter(menu.Options[i].Title);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
