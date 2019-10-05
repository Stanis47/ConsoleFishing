using System;

namespace Engine.Menu
{
    public class MenuOption : BaseMenuOption
    {
        public Action Action { get; }

        public MenuOption(Action action, string title)
        {
            Action = action;
            Title = title;
            ItemColor = new Color
            {
                ForeColor = ConsoleColor.White,
                BackColor = ConsoleColor.Black
            };
        }

        public void Execute()
        {
            Action();
        }
    }
}
