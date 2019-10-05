using Engine.AdvancedMenu;
using System;

namespace Engine.Services
{
    public class ConsoleMenuService : IMenuService
    {
        private Point _startDrawingPoint;

        public ConsoleMenuService(int x, int y)
        {
            _startDrawingPoint = new Point(x, y);
        }

        public void ShowMenu(IMenu menu)
        {
            Console.Clear();
            SelectOption(menu);
        }

        private void Paint(IMenu menu)
        {
            

            for (int i = 0; i < menu.Options.Count; i++)
            {
                Console.SetCursorPosition(_startDrawingPoint.PosX, _startDrawingPoint.PosY + i);

                var color = menu.SelectedIndex == i ? ConsoleColor.Yellow : ConsoleColor.Gray;

                Console.ForegroundColor = color;

                ConsoleWriter.WriteLineCenter(menu.Options[i].Title);

                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private void SelectOption(IMenu menu)
        {
            bool done = false;

            ConsoleWriter.WriteLineCenter(menu.Title);
            Console.WriteLine();

            do
            {
                Paint(menu);

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: menu.MoveDown(); break;
                    case ConsoleKey.Enter: done = true; break;
                }
            }
            while (!done);
        }
    }
}
