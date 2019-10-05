using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Menu
{
    public class MenuManager<T> where T : class
    {
        private Stack<Menu> _menus = new Stack<Menu>();
    }
}
