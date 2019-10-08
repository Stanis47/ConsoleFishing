namespace Engine.Models
{
    public abstract class GearItem
    {
        public int ItemtypeID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public ItemCategory Category { get; set; }

        public GearItem(int itemTypeID, string name, float price)
        {
            ItemtypeID = itemTypeID;
            Name = name;
            Price = price;
        }

        public abstract GearItem Clone();
    }
}
