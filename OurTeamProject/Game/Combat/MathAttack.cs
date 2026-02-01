using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Events;

namespace Game.Combat
{
    internal class MathAttack
    {
        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
        public static void MathAttackMethod(Enemy enemy, Player.Player _player)
        {
            enemy.PrintAttack();
            Console.Clear();
            Console.WriteLine($"{enemy.Name} politely gives you a piece of paper with and pen: ");
            Thread.Sleep(2000);

            for (int i = 1; i <= 4; i++)
            {
                int num1 = Event.RandomNumber(0, 10);
                int num2 = Event.RandomNumber(0, 10);
                Console.Clear();
                Console.WriteLine($"{num1} * {num2} = ?");
                string playersAnswer = Console.ReadLine();
                if (playersAnswer == Convert.ToString(num1 * num2))
                {
                    enemy.Hp -= _player.Attack;
                    Console.Clear();
                }
                else
                {
                    _player.TakeDamage(20);
                    Console.Clear();
                }
            }
        }
    }
}
