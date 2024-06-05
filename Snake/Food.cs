using Snake.Shared;

namespace Snake
{
    public class Food : IFood
    {
        private int width;
        private int height;
        public (int X, int Y) Position { get; private set; }
        private Random random = new Random();

        public Food(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Generate(List<(int X, int Y)> snakeBody)
        {
            do
            {
                Position = (random.Next(1, width - 1), random.Next(1, height - 1));
            } while (snakeBody.Contains(Position));
        }

        public void Draw(IRenderer renderer)
        {
            renderer.DrawAtPosition(Position.X, Position.Y, '@');
        }
    }
}