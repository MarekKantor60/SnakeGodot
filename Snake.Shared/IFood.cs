using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Shared
{
    public interface IFood
    {
        (int X, int Y) Position { get; }
        void Generate(List<(int X, int Y)> snakeBody);
        void Draw(IRenderer renderer);
    }
}
