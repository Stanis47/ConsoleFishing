using Engine.AdvancedMenu;
using Engine.Models;
using Engine.Services;
using System.Collections.Generic;

namespace FishingConsole.ConsoleViews
{
    public class FishListConsoleView : IConsoleView
    {
        private readonly MenuManager _menuManager;
        private readonly IFishService _fishService;

        private Menu _fishMenu = new Menu("Fish List");

        public FishListConsoleView(MenuManager menuManager, IFishService fishService, List<Fish> fishList)
        {
            _menuManager = menuManager;
            _fishService = fishService;
            
            foreach (var fish in fishList)
            {
                MenuOption fishInfo = new MenuOption(() => ShowFishDetails(fish), string.Format("{0, -25} {1, 10} KG", fish.Name, fish.Weight));
                _fishMenu.AddOption(fishInfo);
            }

            MenuOption backOption = new MenuOption(() => _menuManager.Back(), "BACK");
            _fishMenu.AddOption(backOption);
        }

        public void Show()
        {
            _menuManager.Show(_fishMenu);
        }

        private void ShowFishDetails(Fish fish)
        {
            FishConsoleView fishConsoleView = new FishConsoleView(_menuManager, _fishService, fish);
            fishConsoleView.Show();
        }
    }
}
