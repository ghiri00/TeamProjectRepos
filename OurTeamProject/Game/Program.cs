using Game.Core;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameEngine engine = new GameEngine();
            engine.Run();
        }
    }
}
