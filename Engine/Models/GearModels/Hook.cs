namespace Engine.Models
{
    public class Hook : GearItem
    {
        public Hook (int itemTypeID ,string name, float price) : base(itemTypeID ,name, price)
        {
            ItemtypeID = itemTypeID;
            Name = name;
            Price = price;
            Category = ItemCategory.Hook;
        }

        public override GearItem Clone()
        {
            return new Hook(ItemtypeID ,Name, Price);
        }
    }
}
