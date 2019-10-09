using Engine.Models;
using System.Collections.Generic;

namespace Engine.Services
{
    public interface IFishService
    {
        void AddFish(Fish fish);
        void RemoveFish(Fish fish);
        Fish GetFish(int index);
        List<Fish> GetAllFish();
    }
}
