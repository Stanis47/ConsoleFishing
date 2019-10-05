using System;
using System.Collections.Generic;

namespace Engine.Menu
{
    public class ComplexMenuOption : BaseMenuOption
    {
        public ComplexMenuOption(string title, Color color)
        {
            SubOptions = new List<MenuOption>();
            Title = title;
            ItemColor = color;
        }

        public List<MenuOption> SubOptions { get; private set; }
        public int SelectedIndex { get; private set; } = 0;
        public MenuOption SelectedSubOption => SelectedIndex != -1 ? SubOptions[SelectedIndex] : null;

        public void MoveLeft() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);
        public void MoveRight() => SelectedIndex = Math.Min(SelectedIndex + 1, SubOptions.Count - 1);

        public void AddAction(MenuOption menuOption)
        {
            SubOptions.Add(menuOption);
        }

        public void Execute()
        {
            SelectedSubOption.Execute();
        }

        public void ResetSelected()
        {
            SelectedIndex = 0;
        }
    }
}
