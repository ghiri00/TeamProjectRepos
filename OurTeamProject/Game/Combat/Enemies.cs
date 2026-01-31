using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Combat
{
    internal class Enemy
    {
        public string Name;
        public int Hp { get; set; }

        public Enemy(string name, int hp)
        {
            Name = name;
            Hp = hp;
        }
        public Enemy()
        {
            Name = "Unknown";
            Hp = 50;
        }
        public void PrintAttack()
        {
            Console.Clear();
            Console.WriteLine($"{Name} preparing to attack.");
            Thread.Sleep(1000);
        }
        public int RandomNumber(int from, int to)
        {
            Random random = new Random();
            return random.Next(from, to + 1);
        }
    }
}
