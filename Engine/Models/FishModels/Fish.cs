using System;
using System.Collections.Generic;

namespace Engine.Models
{
    public class Fish
    {
        #region Properties

        public int SpeciesID { get; private set; }
        public string Species { get; private set; }
        public Rarity FishRarity { get; private set; }
        public double Weight { get; private set; }
        public double MarginalWeight { get; private set; }
        public string Name { get; private set; }
        public Size FishSize { get; private set; }
        public float Price { get; private set; }
        public List<GearItem> Lures { get; private set; }
        public string[] FishArt { get; private set; }

        #endregion

        public Fish(int speciesID, string species, Rarity rarity, double marginalWeight, List<GearItem> lures, string[] art)
        {
            SpeciesID = speciesID;
            Species = species;
            FishRarity = rarity;
            MarginalWeight = marginalWeight;
            Weight = GenerateSize();
            FishSize = SetSize();
            Name = SetName();
            Price = CalculatePrice();
            Lures = lures;
            FishArt = art;
        }

        public Fish Clone()
        {
            return new Fish(SpeciesID, Species, FishRarity, MarginalWeight, Lures, FishArt);
        }

        #region Private Members

        private float CalculatePrice()
        {
            float price;

            if (Weight >= MarginalWeight)
            {
                price = (float)(((Math.Pow((Weight / MarginalWeight), 2) * 2) * (int)FishRarity) * Weight);
            }
            else
            {
                price = (float)(Weight * (int)FishRarity) / 2;
            }

            float result = (float)Math.Round(price, 2);

            return result;
        }

        private Size SetSize()
        {
            float ratio = (float)(Weight / MarginalWeight);
            Size size;

            if (ratio < 0.5)
            {
                size = Size.Tiny;
            }
            else if (ratio >= 0.5 && ratio < 0.75)
            {
                size = Size.Small;
            } 
            else if (ratio >= 0.75 && ratio <= 1)
            {
                size = Size.Medium;
            }
            else if (ratio > 1 && ratio <= 1.25)
            {
                size = Size.Big;
            }
            else if (ratio > 1.25 && ratio <= 1.5)
            {
                size = Size.VeryBig;
            }
            else
            {
                size = Size.Giant;
            }

            return size;
        }

        private double GenerateSize()
        {
            double minimum = 0.1 * MarginalWeight;
            double maximum = 3 * MarginalWeight;
            double weight;

            Random random = new Random();
            double result = random.NextDouble() * (maximum - minimum) + minimum;

            weight = Math.Round(result, 3);

            return weight;
        }

        private string SetName()
        {
            string prefix = FishSize.ToString();

            string result = ($"{prefix} {Species}");

            return result;
        }

        #endregion
    }
}
