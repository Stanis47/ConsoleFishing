using System;

namespace Engine.Models
{
    public class FishingLine : GearItem
    {
        public float Length { get; set; }
        public float MaxLength { get; set; }
        public string OriginalName { get; set; }

        public FishingLine(int itemTypeID ,string name, float price, float length) : base(itemTypeID ,name, price)
        {
            ItemtypeID = itemTypeID;
            Price = price;
            Length = length;
            MaxLength = length;
            OriginalName = name;
            Name = SetNewName(OriginalName, Length);
            Category = ItemCategory.FishingLine;
        }

        public FishingLine BreakLine(float lengthToBreak)
        {
            if (lengthToBreak > Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            Length -= lengthToBreak;
            Name = SetNewName(OriginalName, Length);
            Price = SetNewPrice();

            return new FishingLine(ItemtypeID, OriginalName, 0.05f, lengthToBreak);
        }

        public FishingLine Take(float meters)
        {
            BreakLine(meters);

            return new FishingLine(ItemtypeID , OriginalName, 0.1f, meters);
        }

        public override GearItem Clone()
        {
            return new FishingLine(ItemtypeID ,Name, Price, Length);
        }

        private float SetNewPrice()
        {
            float newPrice = (Length / MaxLength) * Price;
            float result = (float)Math.Round(newPrice, 2);

            return result;
        }

        private string SetNewName(string name, float length)
        {
            string newName = string.Format("{0} ({1}m)", name, length);

            return newName;
        }
    }
}
