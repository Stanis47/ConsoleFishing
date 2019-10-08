using Engine.AdvancedMenu;

namespace Engine.Services
{
    public interface IMenuService
    {
        void ShowMenu(IMenu menuToShow);
        void ShowActionBar(IMenu actionBar);
    }
}
