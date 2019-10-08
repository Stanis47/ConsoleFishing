using Engine.Models;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Factories
{
    public class GearFactory
    {
        private static List<GearItem> _standardItems;

        static GearFactory()
        {
            _standardItems = new List<GearItem>
            {
                new FishingRod(1001, "Old Rod", 1.99f),
                new FishingRod(1002, "Simple Rod", 4.99f),

                new Reel(1101, "Old Reel", 1.99f),
                new Reel(1102, "Simple Reel", 4.99f),

                new FishingLine(1201, "Old Line", 0.99f, 100),
                new FishingLine(1202, "Simple Line", 2.99f, 150),

                new HooksSet(1351, new Hook(1301, "Old Hook", 0.25f), 3),
                new HooksSet(1352, new Hook(1302, "Simple Hook", 0.49f), 3),

                new Lure(1401, "Bread", 0.01f, 50),
                new Lure(1402, "Worm", 0.02f, 25)
            };
        }

        public static GearItem CreateItemByID(int itemTypeID)
        {
            GearItem standardItem = _standardItems.FirstOrDefault(item => item.ItemtypeID == itemTypeID);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }

            return null;
        }

        public static List<GearItem> CreateLuresByID(params int[] luresID)
        {
            List<GearItem> result = new List<GearItem>();

            foreach (int ID in luresID)
            {
                Lure standardLure = (Lure)_standardItems.FirstOrDefault(lure => lure.ItemtypeID == ID);

                if (standardLure != null)
                {
                    result.Add(standardLure.Clone());
                }
            }

            return result;
        }

        public static List<GearItem> GetListOfStandardItems()
        {
            return _standardItems;
        }
    }
}
