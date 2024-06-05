using Snake.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game : IGame
    {
        private ISnake snake;
        private IFood food;
        private IRenderer renderer;
        private int width;
        private int height;
        private int score;
        private int maxScore;

        private const string MaxScoreFile = "maxscore.txt";

        public Game(ISnake snake, IFood food, IRenderer renderer, int width, int height)
        {
            this.snake = snake;
            this.food = food;
            this.renderer = renderer;
            this.width = width;
            this.height = height;
            this.score = 0;
            this.maxScore = LoadMaxScore();
        }

        public bool IsGameOver { get; private set; }

        public void Start()
        {
            Reset();
            renderer.Initialize(width, height);
            food.Generate(snake.Body);
            while (!IsGameOver)
            {
                Update();
                Draw();
                Thread.Sleep(100);
            }
            if (score > maxScore)
            {
                maxScore = score;
                SaveMaxScore(maxScore);
            }
            renderer.DisplayGameOver(score, width, height);
        }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                snake.ChangeDirection(key);
            }

            if (snake.Move(width, height))
            {
                if (snake.Eat(food.Position))
                {
                    score++;
                    food.Generate(snake.Body);
                }
            }
            else
            {
                IsGameOver = true;
            }
        }

        public void Draw()
        {
            renderer.Clear();
            renderer.DrawBorder(width, height);
            snake.Draw(renderer);
            food.Draw(renderer);
            renderer.DisplayScore(score, width, height);
        }

        private int LoadMaxScore()
        {
            if (File.Exists(MaxScoreFile))
            {
                return int.Parse(File.ReadAllText(MaxScoreFile));
            }
            return 0;
        }

        private void SaveMaxScore(int score)
        {
            File.WriteAllText(MaxScoreFile, score.ToString());
        }

        public int GetMaxScore()
        {
            return maxScore;
        }

        private void Reset()
        {
            score = 0;
            IsGameOver = false;
            snake = new Snake(width / 2, height / 2);
            food = new Food(width, height);
        }
    }
}
