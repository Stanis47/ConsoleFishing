namespace Engine.Models
{
    public class Lure : GearItem
    {
        public int PortionsLeft { get; private set; }
        public string OriginalName { get; set; }
        public float PricePerOne { get; set; } 

        public Lure (int itemTypeID, string name, float price, int portionsCount) : base(itemTypeID, name, price)
        {
            ItemtypeID = itemTypeID;
            PortionsLeft = portionsCount;
            PricePerOne = price;
            Price = price * portionsCount;
            OriginalName = name;
            Name = SetNewName(name);
            Category = ItemCategory.Lure;
        }

        public Lure Use()
        {
            if (PortionsLeft != 0)
            {
                PortionsLeft -= 1;
            }

            Name = SetNewName(OriginalName);
            Price = PricePerOne * PortionsLeft;

            return new Lure(ItemtypeID, OriginalName, PricePerOne, 1);
        }

        public override GearItem Clone()
        {
            return new Lure(ItemtypeID, OriginalName, Price, PortionsLeft);
        }

        private string SetNewName(string name)
        {
            string newName = string.Format("{0} x{1}", name, PortionsLeft);

            return newName;
        }
    }
}
