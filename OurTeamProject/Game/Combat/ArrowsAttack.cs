using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Combat
{
    internal class ArrowsAttack
    {
        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
        public static void ArrowsAttackMethod(Enemy enemy, Player.Player _player)
        {
            enemy.PrintAttack();
            Console.Clear();
            Console.WriteLine("Get ready to dodge!");
            Thread.Sleep(1500);
            Console.Clear();

            Dictionary<ConsoleKey, string> arrows = new Dictionary<ConsoleKey, string>();
            arrows.Add
              (ConsoleKey.LeftArrow,
             "\n     /" +
             "\n    /" +
             "\n   <-----------" +
             "\n   \\" +
             "\n    \\");
            arrows.Add
              (ConsoleKey.UpArrow,
             "\n    ^" +
             "\n  / | \\" +
             "\n /  |  \\" +
             "\n    |" +
             "\n    |");
            arrows.Add
              (ConsoleKey.RightArrow,
             "\n            \\" +
             "\n             \\" +
             "\n   ----------->" +
             "\n             /" +
             "\n            /");
            arrows.Add
              (ConsoleKey.DownArrow,
             "\n    |" +
             "\n    |" +
             "\n    |" +
             "\n \\  | /" +
             "\n   \\|/");
            Random random = new Random();
            List<ConsoleKey> keys = arrows.Keys.ToList();
            for (int i = 1; i <= 5; i++)
            {
                int randomArrow = random.Next(keys.Count);
                ConsoleKey randomKey = keys[randomArrow];

                ClearKeyBuffer();
                Console.WriteLine(arrows[randomKey]);
                var key = Console.ReadKey(true).Key;
                if (key == randomKey)
                {
                    enemy.Hp -= _player.Attack;
                    Console.Clear();
                }
                else
                {
                    _player.TakeDamage(10);
                    Console.Clear();
                }
            }
        }
    }
}
