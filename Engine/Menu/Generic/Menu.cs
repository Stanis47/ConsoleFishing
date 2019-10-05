using System;
using System.Collections.Generic;

namespace Engine.Menu.Generic
{
    public class Menu<T> where T : class
    {
        public Menu(List<T> items, string title)
        {
            Items = items;
        }

        public List<T> Items { get; }
        public int SelectedIndex { get; private set; } = 0;
        public T SelectedOption => SelectedIndex != -1 ? Items[SelectedIndex] : null;

        public void MoveUp() => SelectedIndex = Math.Max(SelectedIndex - 1, 0);
        public void MoveDown() => SelectedIndex = Math.Min(SelectedIndex + 1, Items.Count - 1);
    }
}
