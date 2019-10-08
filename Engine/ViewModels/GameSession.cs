using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;
using System;
using System.Collections.Generic;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }
        public World CurrentWorld { get; set; }
        public FishingRod CurrentRod { get; set; }
        public Lure CurrentLure { get; set; }

        public event EventHandler OnBackpackChanged;
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        public GameSession()
        {
            CurrentPlayer = new Player("Stanis", 10)
            {
                /*Fishnet = FishFactory.CreateFishByID(1001, 1002, 1004, 1005, 1003, 1002, 1001, 1006, 1004, 1004, 1007, 1003,
                                                     1001, 1002, 1004, 1005, 1003, 1002, 1001, 1006, 1004, 1004, 1007, 1003),*/
                Backpack = GearFactory.GetListOfStandardItems()
            };

            WorldFactory factory = new WorldFactory();
            //CurrentWorld = factory.CreateWorld();
        }

        public List<Fish> CurrentFishnet => CurrentPlayer.GetFishInFishnet();

        public void SellAllFish()
        {
            float cash = 0;
            int fishCount = 0;

            if (CurrentFishnet.Count != 0)
            {
                foreach (Fish fish in CurrentFishnet)
                {
                    cash += fish.Price;
                    fishCount++;
                }

                CurrentPlayer.RemoveAllFishFromFishnet();
                CurrentPlayer.ReceiveCash(cash);

                RaiseMessage(string.Format("You sell {0} fish for {1:C}", fishCount, cash));
                RaiseMessage(string.Format("Cash Balance: {0:C}", CurrentPlayer.Cash));
            }
            else
            {
                RaiseMessage("Nothing to sell");
            }
        }

        public void ReleaseAllFish()
        {
            if (CurrentFishnet.Count != 0)
            {
                RaiseMessage(string.Format("{0} fish was released", CurrentFishnet.Count));

                CurrentPlayer.RemoveAllFishFromFishnet();  
            }
            else
            {
                RaiseMessage("Nothing to release");
            }
        }

        public void SellItem(GearItem item)
        {
            if (item != null)
            {
                float price = (float)Math.Round(item.Price / 2, 2);
                CurrentPlayer.Cash += price;
                CurrentPlayer.RemoveItemFromBackpack(item);

                RaiseMessage(string.Format("You sold {0} for {1:C}", item.Name, price));
                RaiseMessage(string.Format("Cash Balance: {0:C}", CurrentPlayer.Cash));

                RaiseBackpackChanged();
            }
        }

        public void InstallReel(Reel reel)
        {
            if (ItemCanBeInstalled)
            {
                if (CurrentRod.CurrentReel != null)
                {
                    RaiseMessage(string.Format("{0} returned to Backpack", CurrentRod.CurrentReel.Name));
                    CurrentPlayer.AddItemToBackpack(CurrentRod.CurrentReel);   
                }

                CurrentPlayer.RemoveItemFromBackpack(reel);
                CurrentRod.InstallReel(reel);

                RaiseMessage(string.Format("{0} installed on {1}", reel.Name, CurrentRod.Name));
            }
            else
            {
                RaiseMessage("Select rod first");
            }
        }

        public void InstallLine(FishingLine fishingLine)
        {
            if (ItemCanBeInstalled)
            {
                if (CurrentRod.CurrentLine != null)
                {
                    RaiseMessage(string.Format("{0} returned to Backpack", CurrentRod.CurrentLine.Name));
                    CurrentPlayer.AddItemToBackpack(CurrentRod.CurrentLine);
                }

                FishingLine line = fishingLine.BreakLine(50);

                if (fishingLine.Length == 0)
                {
                    CurrentPlayer.RemoveItemFromBackpack(fishingLine);
                }

                CurrentRod.InstallLine(line);

                RaiseMessage(string.Format("You install {0}m of {1} on {2}", line.Length, line.OriginalName, CurrentRod.Name));
            }
            else
            {
                RaiseMessage("Select rod first");
            }
        }

        public bool ItemCanBeInstalled => CurrentRod != null;

        public void UseItem(GearItem item)
        {
            switch (item)
            {
                case FishingRod rod:
                    {
                        CurrentRod = rod;
                        RaiseMessage(string.Format("Your current rod is {0}", rod.Name));
                        break;
                    }
                case Reel reel:
                    {
                        InstallReel(reel);
                        break;
                    }
                case FishingLine line:
                    {
                        InstallLine(line);
                        break;
                    }
                case Lure lure:
                    {
                        CurrentLure = lure;
                        RaiseMessage(string.Format("Current lure is {0} ({1} portions left)", lure.OriginalName, lure.PortionsLeft));
                        break;
                    }
                case HooksSet hooksSet:
                    {
                        CurrentRod.InstallHook(hooksSet.TakeOneHook());
                        RaiseMessage(string.Format("You install {0} on {1}", hooksSet.Hook.Name, CurrentRod.Name));
                        break;
                    }
            }

            RaiseBackpackChanged();
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }

        private void RaiseBackpackChanged()
        {
            OnBackpackChanged?.Invoke(this, new System.EventArgs());
        }
    }
}
