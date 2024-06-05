using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Shared
{
    public interface IRenderer
    {
        void Initialize(int width, int height);
        void Clear();
        void DrawBorder(int width, int height);
        void DrawAtPosition(int x, int y, char symbol);
        void DisplayScore(int score, int width, int height);
        void DisplayGameOver(int score, int width, int height);
        void DrawMenu(string[] options, int selectedIndex);
    }
}
