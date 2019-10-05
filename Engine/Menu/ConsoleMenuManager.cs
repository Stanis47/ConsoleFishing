using System;

namespace Engine.Menu
{
    public class ConsoleMenuManager
    {
        public Menu Menu { get; set; }
        public ConsoleMenuPainter MenuPainter { get; set; }

        public Menu CurrentMenu => Menu;
        public MenuItem SelectedOption => Menu.SelectedOption;

        public void Execute()
        {
            if (SelectedOption is Menu)
            {
                if (Menu.Refresher != null)
                {
                    Menu = Menu.Refresher();
                    ShowCurrentMenu();
                }
                else
                {
                    Menu = SelectedOption as Menu;
                    ShowCurrentMenu();
                }
            }
            else if (SelectedOption is MenuOption)
            {
                Console.WriteLine();
                (SelectedOption as MenuOption).Execute();
                ConsoleWriter.WriteLineBottomCenter("Press Enter to continue...");
                Console.ReadLine();

                ShowCurrentMenu();
            }
            else if (SelectedOption is ComplexMenuOption)
            {
                Console.WriteLine();
                (SelectedOption as ComplexMenuOption).Execute();
                ConsoleWriter.WriteLineBottomCenter("Press Enter to continue...");
                Console.ReadLine();

                ShowCurrentMenu();
            }
        }

        public void ShowCurrentMenu()
        {
            MenuPainter = new ConsoleMenuPainter(CurrentMenu);

            Console.Clear();

            Console.SetCursorPosition(2, 1);
            ConsoleWriter.WriteLineCenter(CurrentMenu.Title);

            Color color = new Color
            {
                ForeColor = ConsoleColor.Black,
                BackColor = ConsoleColor.White
            };

            bool done = false;

            do
            {
                MenuPainter.Paint(2, 3);

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: CurrentMenu.MoveUp(); break;
                    case ConsoleKey.DownArrow: CurrentMenu.MoveDown(); break;
                    case ConsoleKey.Escape: break;
                    case ConsoleKey.Enter: done = true; break;
                }
            }
            while (!done);

            Execute();
        }

        public void ShowMenu(Menu menu)
        {
            Menu = menu;
            ShowCurrentMenu();
        }
    }
}
