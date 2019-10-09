using Engine.AdvancedMenu;
using Engine.Models;
using Engine.Services;
using Engine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingConsole.ConsoleViews
{
    public class FishListConsoleView : IConsoleView
    {
        private readonly FishListViewModel _viewModel;
        private readonly MenuManager _menuManager;
        private readonly IFishService _fishService;

        private Menu _fishMenu = new Menu("Fish List");

        public FishListConsoleView(MenuManager menuManager, IFishService fishService, List<Fish> fishList)
        {
            _menuManager = menuManager;
            _fishService = fishService;
            
            foreach (var fish in fishList)
            {
                MenuOption fishInfo = new MenuOption(() => ShowFishDetails(fish), $"{fish.Name}");
                _fishMenu.AddOption(fishInfo);
            }
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
