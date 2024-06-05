using Snake.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ConsoleRenderer : IRenderer
    {
        public void Initialize(int width, int height)
        {
            Console.CursorVisible = false;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void DrawBorder(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, height - 1);
                Console.Write("#");
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(width - 1, i);
                Console.Write("#");
            }
        }

        public void DrawAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        public void DisplayScore(int score, int width, int height)
        {
            Console.SetCursorPosition(0, height + 1);
            Console.Write($"Score: {score}");
        }

        public void DisplayGameOver(int score, int width, int height)
        {
            Console.Clear();
            Console.SetCursorPosition(width / 2 - 5, height / 2);
            Console.Write("Game Over");
            Console.SetCursorPosition(width / 2 - 6, height / 2 + 1);
            Console.Write($"Final Score: {score}");
        }

        public void DrawMenu(string[] options, int selectedIndex)
        {
            Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {options[i]}");
                }
            }
        }
    }
}
