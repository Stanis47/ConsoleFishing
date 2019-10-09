using Engine;
using Engine.AdvancedMenu;
using Engine.Models;
using Engine.Services;
using Engine.ViewModels;
using System;

namespace FishingConsole.ConsoleViews
{
    public class FishConsoleView : IConsoleView
    {
        private readonly FishViewModel _viewModel;
        private readonly MenuManager _menuManager;
        private readonly IFishService _fishService;

        private Menu _actionsMenu;

        public FishConsoleView(MenuManager menuManager, IFishService fishService, Fish fish)
        {
            _menuManager = menuManager;
            _fishService = fishService;
            _viewModel = new FishViewModel(fish, _fishService);
            _actionsMenu = _viewModel.Actions;
            MenuOption backOption = new MenuOption(() => _menuManager.Back(), "BACK");
            _actionsMenu.AddOption(backOption);
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine();
            foreach (var line in _viewModel.Art)
            {
                ConsoleWriter.WriteLineCenter(line);
            }
            Console.WriteLine();

            ConsoleWriter.WriteLineCenter(_viewModel.Species);
            ConsoleWriter.WriteLineCenter(_viewModel.Rarity);
            ConsoleWriter.WriteLineCenter(_viewModel.Size);
            ConsoleWriter.WriteLineCenter(_viewModel.Weight);
            ConsoleWriter.WriteLineCenter(_viewModel.Price);

            ConsoleWriter.WriteLineCenter("Lures:");
            foreach (var lure in _viewModel.Lures)
            {
                ConsoleWriter.WriteLineCenter(lure.Name);
            }

            _menuManager.ShowActionBar(_actionsMenu);
        }
    }
}
