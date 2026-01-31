using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Combat
{
    internal class ArrowsSequenceAttack
    {
        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
        public static void ArrowsSequenceAttackMethod(Enemy enemy, Player.Player _player)
        {
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
            List<ConsoleKey> keys = arrows.Keys.ToList();

            List<ConsoleKey> sequence = new List<ConsoleKey>();
            Random random = new Random();
            int randomArrow;
            Console.Clear();
            enemy.PrintAttack();
            Console.WriteLine("Remember the sequence!");
            Thread.Sleep(1500);
            for (int i = 0; i < 4; i++)
            {
                randomArrow = random.Next(keys.Count);
                ConsoleKey randomKey = keys[randomArrow];
                sequence.Add(randomKey);

                Console.Clear();
                Console.WriteLine(arrows[randomKey]);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Repeat the sequence!");
            ClearKeyBuffer();

            for (int i = 0; i < 4; i++)
            {
                var key = Console.ReadKey(true).Key;

                if (key == sequence[i])
                {
                    enemy.Hp -= _player.Attack;
                    Console.Write(" + ");
                }
                else
                {
                    _player.TakeDamage(20);
                    Console.Write(" - ");
                }
            }
            Thread.Sleep(1200);
        }
    }
}
