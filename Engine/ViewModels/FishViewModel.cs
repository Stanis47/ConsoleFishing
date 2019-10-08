using Engine.AdvancedMenu;
using Engine.Models;
using Engine.Services;
using System.Collections.Generic;

namespace Engine.ViewModels
{
    public class FishViewModel : BaseViewModel
    {
        private readonly Fish _fish;
        private readonly FishService _fishService;

        public string Species => $"Species: {_fish.Species}";
        public string Name => _fish.Name;
        public string Rarity => $"{_fish.FishRarity} Fish";
        public string Size => $"Size: {_fish.FishSize}";
        public string Weight => $"Weight: {_fish.Weight} KG";
        public string Price => $"Price: ${_fish.Price}";
        public List<GearItem> Lures => _fish.Lures;
        public string[] Art => _fish.FishArt;
        public Menu Actions { get; }

        public FishViewModel(Fish fish, FishService fishService)
        {
            _fishService = fishService;
            _fish = fish;
            Actions = new Menu("Actions:");
            MenuOption sellFish = new MenuOption(() => Sell(), "SELL");
            MenuOption releaseFish = new MenuOption(() => Release(), "RELEASE");
            Actions.AddOption(sellFish);
            Actions.AddOption(releaseFish);
        }

        private void Sell()
        {
            _fishService.RemoveFish(_fish);
            RaiseMessage($"{Name} sold for {Price}");
        }

        private void Release()
        {
            _fishService.RemoveFish(_fish);
            RaiseMessage($"{Name} was released");
        }
    }
}
