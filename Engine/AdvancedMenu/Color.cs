using System;

namespace Engine.AdvancedMenu
{
    public class Color
    {
        public readonly ConsoleColor frontColor;
        public readonly ConsoleColor backColor;

        public Color(ConsoleColor front, ConsoleColor back)
        {
            frontColor = front;
            backColor = back;
        }
    }
}
