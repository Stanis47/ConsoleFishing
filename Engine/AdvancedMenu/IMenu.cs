using System.Collections.Generic;

namespace Engine.AdvancedMenu
{
    public interface IMenu
    {
        string Title { get; }
        List<MenuOption> Options { get; }
        int SelectedIndex { get; set; }
        MenuOption SelectedOption { get; }

        void MoveUp();
        void MoveDown();
        void ResetSelected();
        void AddOption(MenuOption option);
    }
}
