using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Shared
{
    public interface ISnake
    {
        List<(int X, int Y)> Body { get; }
        void ChangeDirection(ConsoleKey key);
        bool Move(int width, int height);
        bool Eat((int X, int Y) foodPosition);
        void Draw(IRenderer renderer);
    }
}
