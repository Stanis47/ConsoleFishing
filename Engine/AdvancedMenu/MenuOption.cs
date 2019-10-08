using System;

namespace Engine.AdvancedMenu
{
    public class MenuOption
    {
        private readonly Action _action;

        public string Title { get; private set; }

        public MenuOption(Action action, string title)
        {
            _action = action;
            Title = title;
        }

        public void Execute()
        {
            _action();
        }
    }
}
