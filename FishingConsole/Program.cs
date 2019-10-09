using Engine;
using Engine.AdvancedMenu;
using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;
using Engine.Services;
using Engine.ViewModels;
using FishingConsole.ConsoleViews;
using System;
using System.Collections.Generic;

namespace FishingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenuService menuService = new ConsoleMenuService(2, 3);
            IFishService fishService = new FishService();
            MenuManager menuManager = new MenuManager(menuService);

            List<Fish> fishList = FishFactory.CreateFishByID(1005, 1001, 1002, 1005, 1003, 1004);
            //FishConsoleView view = new FishConsoleView(menuManager, fishService, fish);
            FishListConsoleView view = new FishListConsoleView(menuManager, fishService, fishList);
            
            Menu menu = new Menu("Main Menu");
            Menu menu1 = new Menu("Secondary Menu");
            Menu menu2 = new Menu("Third Menu");

            MenuOption option1 = new MenuOption(() => ConsoleWriter.WriteLineCenter("Option1 selected"), "Option1");
            MenuOption option2 = new MenuOption(() => ConsoleWriter.WriteLineCenter("Option2 selected"), "Option2");
            MenuOption option3 = new MenuOption(() => ConsoleWriter.WriteLineCenter("Option3 selected"), "Option3");
            MenuOption option4 = new MenuOption(() => ConsoleWriter.WriteLineCenter("Option4 selected"), "Option4");
            MenuOption option5 = new MenuOption(() => ConsoleWriter.WriteLineCenter("Option5 selected"), "Option5");
            MenuOption option6 = new MenuOption(() => menuManager.Show(menu1), "Show Secondary Menu");
            MenuOption option8 = new MenuOption(() => menuManager.Show(menu2), "Show Third Menu");
            MenuOption option7 = new MenuOption(() => menuManager.Back(), "Back");
            MenuOption option9 = new MenuOption(() => view.Show(), "Show Fish");
            MenuOption exit = new MenuOption(() => Environment.Exit(0), "Exit");

            menu.AddOption(option1);
            menu.AddOption(option2);
            menu.AddOption(option3);
            menu.AddOption(option4);
            menu.AddOption(option5);
            menu.AddOption(option6);
            menu.AddOption(exit);

            menu1.AddOption(option1);
            menu1.AddOption(option2);
            menu1.AddOption(option3);
            menu1.AddOption(option4);
            menu1.AddOption(option8);
            menu1.AddOption(option7);

            menu2.AddOption(option1);
            menu2.AddOption(option2);
            menu2.AddOption(option3);
            menu2.AddOption(option9);
            menu2.AddOption(option4);
            menu2.AddOption(option7);

            menuManager.Show(menu);

            Console.ReadLine();
        }
    }
}
