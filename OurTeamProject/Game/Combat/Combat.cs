using Game.Core;
using Game.Events;
using Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Game.Combat
{
    internal class CombatClass
    {
        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
        public static int RandomNumber(int from, int to)
        {
            Random random = new Random();
            return random.Next(from, to + 1);
        }
        public static void MobCombat(Enemy mob, Player.Player _player)
        {
            Console.Clear();
            Console.WriteLine($"The battle began with: {mob.Name}");
            Thread.Sleep(1500);

            string choise;
            while ((mob.Hp > 0 && _player.HP > 0))
            {
                Console.Clear();
                Console.WriteLine($"" +
                    $"Your HP: {_player.HP}\n" +
                    $"{mob.Name}'s Hp: {mob.Hp}\n\n" +
                    $"Actions:\n" +
                    $"1 - Fight\n" +
                    $"2 - Heal\n" +
                    $"3 - Run away");
                ClearKeyBuffer();
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Attack(mob, _player);
                        break;
                    case "2":
                        { 
                            _player.Heal(15); 
                            int randomNumber = RandomNumber(1, 4);
                            if (randomNumber == 1)
                            {
                                Console.Clear();
                                Console.WriteLine($"The enemy also managed to heal.");
                                mob.Hp += 10;
                                Thread.Sleep(1000);
                            }
                            break;
                        }
                    case "3":
                        {
                            int randomNumber = RandomNumber(1, 3);
                            if(randomNumber == 1 && mob.Name != "Old sage")
                            {
                                Console.Clear();
                                Console.WriteLine($"You managed to escape from { mob.Name}!");
                                Thread.Sleep(1500);
                                return;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"You failed to escape from {mob.Name}!");
                                Thread.Sleep(1500);
                                Attack(mob, _player);
                            }
                            break;
                        }
                    default:
                        break;
                }
            } 
            if (mob.Hp <= 0)
            {
                _player.AddXP(100);
                Console.Clear();
                Console.WriteLine($"You defeated the {mob.Name}!");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        private static void Attack(Enemy mob, Player.Player _player)
        {
            int randomNumber = RandomNumber(1, 3);
            if (randomNumber == 1)
                ArrowsAttack.ArrowsAttackMethod(mob, _player);
            else if (randomNumber == 2)
                ArrowsSequenceAttack.ArrowsSequenceAttackMethod(mob, _player);
            else if (randomNumber == 3)
                MathAttack.MathAttackMethod(mob, _player);
        }
    }
}
