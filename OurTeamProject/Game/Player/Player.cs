using System;

namespace Game.Player
{
    public class Player
    {
        public string Name { get; private set; }

        public int MaxHP { get; private set; } = 100;
        public int HP { get; private set; }

        public int Attack { get; private set; } = 10;
        public int Defense { get; private set; } = 5;

        public int Level { get; private set; } = 1;
        public int XP { get; private set; } = 0;

        public bool IsAlive => HP > 0;

        public Player(string name)
        {
            Name = name;
            HP = MaxHP;
        }

        public void TakeDamage(int damage)
        {
            int finalDamage = Math.Max(0, damage - Defense);
            HP -= finalDamage;

            if (HP < 0)
                HP = 0;
        }

        public void Heal(int amount)
        {
            HP += amount;
            if (HP > MaxHP)
                HP = MaxHP;
        }

        public void AddXP(int amount)
        {
            XP += amount;

            if (XP >= Level * 100)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            XP = 0;
            Level++;
            MaxHP += 10;
            Attack += 2;
            Defense += 1;
            HP = MaxHP;

            Console.WriteLine("⬆️ Level Up!");
        }
    }
}

