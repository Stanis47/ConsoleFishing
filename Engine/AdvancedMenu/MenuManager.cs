using Engine.Services;
using System.Collections.Generic;

namespace Engine.AdvancedMenu
{
    public class MenuManager
    {
        private readonly IMenuService _menuService;

        private Stack<IMenu> _menus = new Stack<IMenu>();
        private IMenu _currentMenu;

        public IMenu CurrentMenu
        {
            get => _currentMenu;
            set
            {
                _menus.Push(_currentMenu);
                _currentMenu = value; 
            }
        }

        public MenuOption CurrentOption => CurrentMenu.SelectedOption;

        public MenuManager(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void Show(IMenu menu)
        {
            CurrentMenu = menu;
            _menuService.ShowMenu(_currentMenu);
            ExecuteSelected();
        }

        public void Back()
        {
            var menuToShow = _menus.Pop();
            CurrentMenu = menuToShow;
            _menuService.ShowMenu(menuToShow);
            ExecuteSelected();
        }

        private void ExecuteSelected()
        {
            CurrentOption.Execute();
        }
    }
}
