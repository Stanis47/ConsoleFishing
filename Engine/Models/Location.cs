using System.Collections.Generic;

namespace Engine.Models
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Fish> LocalFish { get; set; }

        public Location(string name, string description, List<Fish> localFish)
        {
            Name = name;
            Description = description;
            LocalFish = localFish;
        }

        public List<Fish> GetListOfLocalFish()
        {
            return LocalFish;
        }
    }
}
