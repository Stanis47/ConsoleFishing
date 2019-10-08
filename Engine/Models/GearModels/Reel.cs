namespace Engine.Models
{
    public class Reel : GearItem
    {
        public Reel(int itemTypeID , string name, float price) : base(itemTypeID, name, price)
        {
            ItemtypeID = itemTypeID;
            Name = name;
            Price = price;
            Category = ItemCategory.Reel;
        }

        public override GearItem Clone()
        {
            return new Reel(ItemtypeID ,Name, Price);
        }
    }
}
