using System;
using System.Collections.Generic;

namespace Engine.AdvancedMenu
{
    public class Menu : IMenu
    {
        public Menu(string title)
        {
            Options = new List<MenuOption>();
            Title = title;
        }

        public string Title { get; private set; }
        public List<MenuOption> Options { get; private set; }
        public int SelectedIndex { get; set; } = 0;
        public MenuOption SelectedOption => SelectedIndex != -1 ? Options[SelectedIndex] : null;

        public void MoveUp() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);
        public void MoveDown() => SelectedIndex = Math.Min(SelectedIndex + 1, Options.Count - 1);
        public void ResetSelected() => SelectedIndex = 0;

        public void AddOption(MenuOption option)
        {
            Options.Add(option);
        }
    }
}
