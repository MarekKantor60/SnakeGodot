using Snake.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 40;
            int height = 20;

            IRenderer renderer = new ConsoleRenderer();
            Menu menu = new Menu(renderer);

            while (true)
            {
                int choice = menu.Show();
                if (choice == 0) // Start
                {
                    ISnake snake = new Snake(width / 2, height / 2);
                    IFood food = new Food(width, height);
                    IGame game = new Game(snake, food, renderer, width, height);
                    game.Start();
                }
                else if (choice == 1) // Max Score
                {
                    renderer.Clear();
                    IGame tempGame = new Game(new Snake(width / 2, height / 2), new Food(width, height), renderer, width, height);
                    renderer.DisplayScore(tempGame.GetMaxScore(), width, height);
                    Console.ReadKey(true);
                }
                else if (choice == 2) // Quit
                {
                    break;
                }
            }
        }
    }
}