using System;

namespace Engine.Models
{
    public class FishingRod : GearItem
    {
        public GearItem CurrentReel { get; private set; }
        public GearItem CurrentLine { get; private set; }
        public GearItem CurrentHook { get; private set; }
        public GearItem CurrentLure { get; private set; }

        public FishingRod(int itemTypeID ,string name, float price) : base(itemTypeID ,name, price)
        {
            ItemtypeID = itemTypeID;
            Name = name;
            Price = price;
            Category = ItemCategory.FishingRod;
        }

        #region Public Methods

        public bool IsReady => CheckRod();

        public void InstallReel(GearItem reel)
        {
            if (reel.Category != ItemCategory.Reel)
            {
                throw new ArgumentException("Category must be Reel");
            }

            CurrentReel = reel;
        }

        public void InstallLine(GearItem line)
        {
            if (line.Category != ItemCategory.FishingLine)
            {
                throw new ArgumentException("Category must be FishingLine");
            }

            CurrentLine = line;
        }

        public void InstallHook(GearItem hook)
        {
            if (hook.Category != ItemCategory.Hook)
            {
                throw new ArgumentException("Category must be Hook");
            }

            CurrentHook = hook;
        }

        public void InstallLure(GearItem lure)
        {
            if (lure.Category != ItemCategory.Lure)
            {
                throw new ArgumentException("Category must be Lure");
            }

            CurrentLure = lure;
        }

        public void Cast()
        {
            if (IsReady)
            {
                
            }
        }

        public override GearItem Clone()
        {
            return new FishingRod(ItemtypeID ,Name, Price);
        }

        #endregion

        #region Private Members

        private bool CheckRod()
        {
            return (_reelIsReady && _lineIsReady && _hookIsReady && _lureIsReady);
        }

        private bool _reelIsReady => CurrentReel != null;
        private bool _lineIsReady => CurrentLine != null;
        private bool _hookIsReady => CurrentHook != null;
        private bool _lureIsReady => CurrentLure != null;

        #endregion
    }
}
