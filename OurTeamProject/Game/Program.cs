using Game.Combat;
using Game.Core;
using Game.Events;
using Game.Player;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();
            engine.Run();
        }
    }
}