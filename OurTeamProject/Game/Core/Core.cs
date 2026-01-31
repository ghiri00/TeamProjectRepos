using Game.Player;
using System;
using Game.Events;

namespace Game.Core
{
    public class GameEngine
    {
        private Player.Player _player;
        private int _day = 1;
        public bool _isRunning = true;

        public GameEngine()
        {
            _player = new Player.Player("Survivor");
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Console RPG Survival ===");

            while (_isRunning && _player.IsAlive)
            {
                Console.WriteLine($"\n📆 Day {_day}");
                ShowMenu();
                HandleInput();
                _day++;
            }

            HandleDeath();
        }

        private void ShowMenu()
        {
            Console.WriteLine("\nChoose action:");
            Console.WriteLine("1. Explore");
            Console.WriteLine("2. Rest");
            Console.WriteLine("3. Check Status");
            Console.WriteLine("4. Exit");
        }

        private void HandleInput()
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Explore();
                    break;
                case "2":
                    Rest();
                    break;
                case "3":
                    ShowStatus();
                    break;
                case "4":
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("❌ Invalid choice");
                    break;
            }
        }

        private void Explore()
        {
            Console.WriteLine("🌲 You explore the area...");
            //_player.TakeDamage(5); // тимчасово, поки немає Combat/EventSystem
            //Console.WriteLine("⚠️ You got hurt during exploration!");
            Event.RandomEvent(_player);
        }

        private void Rest()
        {
            Console.WriteLine("😴 You take a rest...");
            _player.Heal(10);
        }

        private void ShowStatus()
        {
            Console.WriteLine("\n=== STATUS ===");
            Console.WriteLine($"Name: {_player.Name}");
            Console.WriteLine($"HP: {_player.HP}/{_player.MaxHP}");
            Console.WriteLine($"Attack: {_player.Attack}");
            Console.WriteLine($"Defense: {_player.Defense}");
            Console.WriteLine($"Level: {_player.Level}");
            Console.WriteLine($"XP: {_player.XP}");
        }

        private void HandleDeath()
        {
            if (!_player.IsAlive)
            {
                Console.WriteLine("\n💀 You died...");
                Console.WriteLine($"You survived {_day} days.");
            }

            Console.WriteLine("Game Over.");
        }
    }
}

