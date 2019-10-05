using System;
using System.Collections.Generic;

namespace Engine.Menu
{
    public class Menu : MenuItem
    {
        public Menu(string title)
        {
            Options = new List<MenuItem>();
            Title = title;
            ItemColor = new Color
            {
                ForeColor = ConsoleColor.White,
                BackColor = ConsoleColor.Black
            };
        }

        public List<MenuItem> Options { get; private set; }
        public int SelectedIndex { get; set; } = 0;
        public MenuItem SelectedOption => SelectedIndex != -1 ? Options[SelectedIndex] : null;
        public Func<Menu> Refresher { get; set; }

        public void MoveUp() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);
        public void MoveDown() => SelectedIndex = Math.Min(SelectedIndex + 1, Options.Count - 1);

        public void AddMenuItem(MenuItem menuItem)
        {
            Options.Add(menuItem);
        }

        public void AddMenuItem(Func<Menu> func)
        {
            Refresher = func;
            Options.Add(func());
        }

        public void ResetSelected()
        {
            SelectedIndex = 0;
        }
    }
}
