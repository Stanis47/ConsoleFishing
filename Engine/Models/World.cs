using System.Collections.Generic;
using System.Linq;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        public void AddLocation(string name, string description, List<Fish> fish)
        {
            Location location = new Location(name, description, fish);

            _locations.Add(location);
        }

        public Location GetLocationByName(string name)
        {
            return _locations.FirstOrDefault(loc => loc.Name == name);
        }

        public List<Location> GetAllLocations()
        {
            return _locations;
        }
    }
}
