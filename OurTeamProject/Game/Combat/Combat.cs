using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game.Combat
{
    internal class Combat
    {

    }

    internal class Enemy
    {
        private protected string Name;
        private protected int Hp;
        private protected int Difficulty; // від 1 до 5

        public Enemy(string name, int hp, int diff)
        {
            Name = name;
            Hp = hp;
            Difficulty = diff;
        }
        public Enemy()
        {
            Name = "Невідоме ім'я";
            Hp = 50;
            Difficulty = 1;
        }
        public void PrintAttack()
        {
            Console.Clear();
            Console.WriteLine($"{Name} готується до атаки.");
            Thread.Sleep(1500);
        }
        public void PrintDeath()
        {
            Console.Clear();
            Console.WriteLine($"{Name} помирає.");
            Thread.Sleep(1500);
        } 
        public void ArrowsAttack() // гравцю потрібно вчасно натискати на стрілочки
        {
            Random random = new Random();
            int randomArrow;
            int count = 0;

            PrintAttack();
            Console.Clear();
            Console.WriteLine("Готуйтеся ухилятись!");
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
            List<ConsoleKey> keys = arrows.Keys.ToList(); // можливість звертатися за індексами
            for (int i = 1; i <= 5; i++)
            {
                randomArrow = random.Next(keys.Count);
                ConsoleKey randomKey = keys[randomArrow];

                Console.WriteLine(arrows[randomKey]);
                var key = Console.ReadKey(true).Key;
                if (key == randomKey)
                {
                    count++;
                    Console.WriteLine(":)");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(":(");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
            if(count == 5)
            {
                PrintDeath();
            }
            else
            {
                Console.WriteLine("Ви програли.");
            }
        }
    }
    internal class Boar : Enemy // перший супротивник
    {
        public Boar() : base("Кабан", 50, 1)
        {
        }
    }
    internal class Slime : Enemy //другий супротивник
    {
        public Slime() : base("Слайм", 50, 2)
        {
        }
    }
    internal class Centaur : Enemy // третій супротивник
    {
        public Centaur() : base("Дикий кентавр", 150, 4)
        {
        }
    }
}
