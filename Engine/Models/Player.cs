using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Models
{
    public class Player
    {
        #region Properties

        public string Name { get; set; }
        public float Cash { get; set; }
        public List<GearItem> Backpack { get; set; }
        public List<Fish> Fishnet { get; set; }

        #endregion

        public Player(string name, float cash)
        {
            Name = name;
            Cash = cash;

            Backpack = new List<GearItem>();
            Fishnet = new List<Fish>();
        }

        #region Public Methods

        public List<GearItem> Rods => Backpack.Where(item => item.Category == ItemCategory.FishingRod).ToList();
        public List<GearItem> Reels => Backpack.Where(item => item.Category == ItemCategory.Reel).ToList();
        public List<GearItem> Lines => Backpack.Where(item => item.Category == ItemCategory.FishingLine).ToList();
        public List<GearItem> Hooks => Backpack.Where(item => item.Category == ItemCategory.SetOfHooks).ToList();
        public List<GearItem> Lures => Backpack.Where(item => item.Category == ItemCategory.Lure).ToList();

        public void AddItemToBackpack(GearItem item)
        {
            if (item != null)
            {
                Backpack.Add(item);
            }
        }

        public void RemoveItemFromBackpack(GearItem item)
        {
            if (item != null && Backpack.Contains(item))
            {
                Backpack.Remove(item);
            }
        }

        public List<GearItem> GetItemsInBackpack()
        {
            return Backpack;
        }

        public void AddFishToFishnet(Fish fish)
        {
            if (fish != null)
            {
                Fishnet.Add(fish);
            }
        }

        public void RemoveFishFromFishnet(Fish fish)
        {
            if (fish != null && Fishnet.Contains(fish))
            {
                Fishnet.Remove(fish);
            }
        }

        public void RemoveAllFishFromFishnet()
        {
            Fishnet.Clear();
        }

        public List<Fish> GetFishInFishnet()
        {
            return Fishnet;
        }

        public void ReceiveCash(float amountOfCash)
        {
            Cash += amountOfCash;
        }

        public void SpendCash(float amountOfCash)
        {
            if (amountOfCash > Cash)
            {
                throw new ArgumentOutOfRangeException($"{Name} only has {Cash}$, and can`t spend {amountOfCash}$.");
            }

            Cash -= amountOfCash;
        }

        #endregion
    }
}
