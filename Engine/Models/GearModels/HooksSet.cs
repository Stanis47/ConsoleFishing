namespace Engine.Models
{
    public class HooksSet : GearItem
    {
        public Hook Hook { get; set; }
        public int NumberOfHooks { get; private set; }
        public int MaxNumberOfHooks { get; set; }
        public bool IsEmpty { get; private set; }
        public string OriginalName { get; set; }

        public HooksSet(int itemTypeID ,Hook hook, int numberOfHooks) : base(itemTypeID ,hook.Name, hook.Price)
        {
            ItemtypeID = itemTypeID;
            Hook = hook;
            Price = Hook.Price * numberOfHooks;
            NumberOfHooks = numberOfHooks;
            OriginalName = hook.Name;
            Name = SetNewName(hook.Name);
            IsEmpty = false;
            Category = ItemCategory.SetOfHooks;
        }

        public Hook TakeOneHook()
        {
            if (IsEmpty)
            {
                return null;
            }
            NumberOfHooks -= 1;

            Name = SetNewName(OriginalName);
            Price = Hook.Price * NumberOfHooks;

            return Hook;
        }

        public override GearItem Clone()
        {
            return new HooksSet(ItemtypeID ,Hook, NumberOfHooks);
        }

        private string SetNewName(string name)
        {
            string newName = string.Format("{0} x{1}", name, NumberOfHooks);

            return newName;
        }
    }
}
