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

<<<<<<< HEAD

// Цей коментар вніс Данило
=======
// Цей коментар вніс Данило // Це мої зміни!!!
>>>>>>> b48d35cc7f7f3ae2507c8631fbb6b9b7f10dbfe9
// Цей коментар знову вніс Данило
