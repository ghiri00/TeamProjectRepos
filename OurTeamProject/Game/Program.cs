using Game.Combat;
using Game.Core;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //===============================
            // тестування методу ArrowsAttack()
            Enemy enemy = new();
            enemy.ArrowsAttack();
            //================================
            GameEngine engine = new GameEngine();
            engine.Run();
        }
    }
}


// Цей коментар вніс Данило
// Цей коментар знову вніс Данило
