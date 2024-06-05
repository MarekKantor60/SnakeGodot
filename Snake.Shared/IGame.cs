namespace Snake.Shared
{
    public interface IGame
    {
        void Start();
        void Update();
        void Draw();
        bool IsGameOver { get; }
        int GetMaxScore();
    }
}
