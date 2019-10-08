using Engine.Models;
using System.Collections.Generic;

namespace Engine.Services
{
    public class FishService
    {
        private List<Fish> _catchedFish = new List<Fish>();

        public void AddFish(Fish fish)
        {
            if (fish != null)
            {
                _catchedFish.Add(fish);
            }
        }

        public void RemoveFish(Fish fish)
        {
            if (fish != null)
            {
                _catchedFish.Remove(fish);
            }
        }

        public Fish GetFish(int index)
        {
            return _catchedFish[index];
        }

        public List<Fish> GetAllFish()
        {
            return _catchedFish;
        }
    }
}
