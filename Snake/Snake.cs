using Snake.Shared;

namespace Snake
{
    public class Snake : ISnake
    {
        public List<(int X, int Y)> Body { get; private set; }
        private (int X, int Y) direction;

        public Snake(int startX, int startY)
        {
            Body = new List<(int, int)> { (startX, startY) };
            direction = (1, 0);
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (direction != (0, 1)) direction = (0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != (0, -1)) direction = (0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != (1, 0)) direction = (-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != (-1, 0)) direction = (1, 0);
                    break;
            }
        }

        public bool Move(int width, int height)
        {
            (int X, int Y) newHead = (Body[0].X + direction.X, Body[0].Y + direction.Y);

            if (newHead.X <= 0 || newHead.X >= width - 1 || newHead.Y <= 0 || newHead.Y >= height - 1 || Body.Contains(newHead))
            {
                return false;
            }

            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
            return true;
        }

        public bool Eat((int X, int Y) foodPosition)
        {
            if (Body[0] == foodPosition)
            {
                Body.Add(Body[Body.Count - 1]);
                return true;
            }
            return false;
        }

        public void Draw(IRenderer renderer)
        {
            foreach (var part in Body)
            {
                renderer.DrawAtPosition(part.X, part.Y, 'O');
            }
        }
    }
}