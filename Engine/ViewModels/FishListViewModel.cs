using Engine.Models;
using System.Collections.Generic;

namespace Engine.ViewModels
{
    public class FishListViewModel
    {
        public List<Fish> FishList { get; }

        public FishListViewModel(List<Fish> fishList)
        {
            FishList = fishList; 
        }
    }
}
