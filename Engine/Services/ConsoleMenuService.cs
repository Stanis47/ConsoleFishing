using Engine.AdvancedMenu;
using System;

namespace Engine.Services
{
    public class ConsoleMenuService : IMenuService
    {
        private Point _startDrawingPoint;
        private Color _color = new Color(ConsoleColor.Black, ConsoleColor.White);

        public ConsoleMenuService(int x, int y)
        {
            _startDrawingPoint = new Point(x, y);
        }

        public void ShowMenu(IMenu menu)
        {
            Console.Clear();
            SelectOption(menu, false);
        }

        public void ShowActionBar(IMenu actionBar)
        {
            SelectOption(actionBar, true);
        }

        private void Paint(IMenu menu, bool asActionBar, int cursorTop = 0, Color color = null)
        {
            for (int i = 0; i < menu.Options.Count; i++)
            {
                if (asActionBar)
                    Console.SetCursorPosition(_startDrawingPoint.PosX, cursorTop + i);
                else
                    Console.SetCursorPosition(_startDrawingPoint.PosX, _startDrawingPoint.PosY + i);

                if (menu.SelectedIndex == i)
                {
                    if (color != null)
                    {
                        Console.ForegroundColor = color.frontColor;
                        Console.BackgroundColor = color.backColor;
                    }
                    else
                    {
                        Console.ForegroundColor = _color.frontColor;
                        Console.BackgroundColor = _color.backColor;
                    }
                }

                ConsoleWriter.WriteLineCenter(menu.Options[i].Title);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        private void SelectOption(IMenu menu, bool asActionBar)
        {
            bool done = false;
            int cursorTop = 0;
            
            ConsoleWriter.WriteLineCenter(menu.Title);
            Console.WriteLine();

            if (asActionBar)
            {
                cursorTop = Console.CursorTop;
            }
            
            do
            {
                Paint(menu, asActionBar, cursorTop);

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
