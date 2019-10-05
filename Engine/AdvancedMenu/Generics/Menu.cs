using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.AdvancedMenu.Generics
{
    public class Menu<T>
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
    }
}
