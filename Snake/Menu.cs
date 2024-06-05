using Snake.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Menu
    {
        private string[] options = { "Start", "Max Score", "Quit" };
        private int selectedIndex = 0;
        private IRenderer renderer;

        public Menu(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public int Show()
        {
            ConsoleKey key;
            do
            {
                renderer.Clear();
                renderer.DrawMenu(options, selectedIndex);
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                }

            } while (key != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
