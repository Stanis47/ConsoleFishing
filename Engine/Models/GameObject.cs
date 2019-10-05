using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class GameObject
    {
        public string Name { get; private set; }
        public List<Action> Actions { get; private set; } = new List<Action>();
    }
}
