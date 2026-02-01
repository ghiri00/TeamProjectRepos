using Game.Combat;
using Game.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game.Player;
using System.Reflection.Metadata;

namespace Game.Events
{
    internal class Event
    {
        public string Name;
        public Enemy Npc;
        public Event(string Name_, Enemy Npc_)
        {
            Name = Name_;
            Npc = Npc_;
        }
        public static int RandomNumber(int from, int to)
        {
            Random random = new Random();
            return random.Next(from, to + 1);
        }
        public static void RandomEvent(Player.Player _player)
        {
            for (int i = 0; i < 3; i++)
            {
                Event biom = RandomBiom();
                Console.Clear();
                Console.WriteLine($"You’re strolling somewhere...");
                Thread.Sleep(1500);
                Console.WriteLine($"You ended up in {biom.Name}.");
                Thread.Sleep(1500);

                int randomNumber = RandomNumber(1, 2);
                if (randomNumber == 1)
                {
                    NpcAppearance(biom.Npc);
                    NpcInteractionMenu(biom.Npc, _player);
                }
                else
                {
                    Enemy mob = biom.RandomMobSpawn();
                    CombatClass.MobCombat(mob, _player);
                }
                if (_player.HP <= 0)
                    return;
            }
        }
        public static void NpcInteractionMenu(Enemy Npc, Player.Player _player)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine($"Actions with: {Npc.Name}\n" +
                    $"0 - Leave\n" +
                    $"1 - Chat\n" +
                    $"2 - Beat\n");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Without a word, you turned around and walked back.");

                        return;
                    case 1:
                        {
                            int randomNumber = RandomNumber(1, 2);
                            if (randomNumber == 1)
                            {
                                Console.Clear();
                                Console.WriteLine($"The conversation went well, " +
                                    $"even though you were a bit tired from all the chatter..");
                                Thread.Sleep(1500);
                                Console.Clear();
                                _player.AddXP(40);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine($"It seems you won't find anything to talk about today");
                                Console.WriteLine($"On the way back, you were bitten by a snake. Ouch.");
                                _player.TakeDamage(5);
                                Thread.Sleep(3000);
                                Console.Clear();
                            }
                            return;
                        }
                    case 2:
                        {
                            CombatClass.MobCombat(Npc, _player);
                            return;
                        }
                    default:
                        break;
                }
            } while (true);
        }
        public static Event RandomBiom()
        {
            int randomNumber = RandomNumber(1, 4);

            switch (randomNumber)
            {
                case 1:
                    {
                        DenseForest biom = new DenseForest();
                        return biom;
                    }
                case 2:
                    {
                        WildflowerField biom = new WildflowerField();
                        return biom;
                    }
                case 3:
                    {
                        DryGrassland biom = new DryGrassland();
                        return biom;
                    }
                case 4:
                    {
                        RunestoneCircle biom = new RunestoneCircle();
                        return biom;
                    }
                default:
                    {
                        Console.WriteLine("Error in RandomBiom.");
                        DenseForest biom = new DenseForest();
                        return biom;
                    }
            }
        }
        protected void PrintEnemyEntry(string place, Enemy mob)
        {
            Console.Clear();
            Console.WriteLine($"{mob.Name} appeared {place}.");
            Thread.Sleep(1500);
        }
        public static void NpcAppearance(Enemy npc)
        {
            Console.Clear();
            Console.WriteLine($"From behind comes {npc.Name}");
            Thread.Sleep(1500);

        }
        protected Enemy RandomMob(Enemy mob1, Enemy mob2)
        {
            if (RandomNumber(1, 2) == 1)
                return mob1;
            else
                return mob2;
        }
        public virtual Enemy RandomMobSpawn()
        {
            return null;
        }
        public static bool FinalAct(Player.Player _player)
        {
            Console.Clear();
            Console.WriteLine("You have approached the border of the area...");
            Thread.Sleep(2000);
            if (_player.Level < 3)
            {
                Console.Clear();
                Console.WriteLine("But you don't think you're ready to leave yet...");
                Thread.Sleep(2500);
                Console.Clear();
                return false;
            }
            Console.WriteLine("And you think you can do it...");
            Thread.Sleep(2000);
            string choice = "x";
            do
            {
                Console.Clear();
                Console.WriteLine("Are you sure you're ready to fight the final boss \n" +
                    "with no chance of turning back?\n" +
                    "1 - Yes\n" +
                    "2 - No");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        return false;
                    default:
                        choice = "x";
                        break;
                }
            } while (choice == "x");

            UIclass.FinalDialogue();
            Enemy boss = new("Old sage", 500);

            CombatClass.MobCombat(boss, _player);
            if (_player.HP <= 0)
                return false;
            else
                UIclass.AfterWinDialogue();
            return true;
        }
    }
    internal class DenseForest : Event
    {
        public Enemy mob1 = new("Bat", 50);
        public Enemy mob2 = new("Weak shadow demon", 60);
        public DenseForest() : base("DenseForest", new Enemy("The injured hunter", 150)){}
        public override Enemy RandomMobSpawn()
        {
            Enemy randomMob = RandomMob(mob1, mob2);
            PrintEnemyEntry("from shadow", randomMob);
            return randomMob;
        }
    }
    internal class WildflowerField : Event
    {
        public Enemy mob1 = new("Slime", 50);
        public Enemy mob2 = new("Giant wasp", 100);
        public WildflowerField() : base("WildflowerField", new Enemy("Queen of Fairies", 200)){}
        public override Enemy RandomMobSpawn()
        {
            Enemy randomMob = RandomMob(mob1, mob2);
            PrintEnemyEntry("out of nowhere", randomMob);
            return randomMob;
        }

    }
    internal class DryGrassland : Event
    {
        public Enemy mob1 = new("Wild boar", 100);
        public Enemy mob2 = new("Giant centipede", 150);
        public DryGrassland() : base("Dry grassland", new Enemy("The herbalist", 250)){}

        public override Enemy RandomMobSpawn()
        {
            Enemy randomMob = RandomMob(mob1, mob2);
            PrintEnemyEntry("from behind the dry bushes", randomMob);
            return randomMob;
        }
    }
    internal class RunestoneCircle : Event
    {
        public Enemy mob1 = new("Shadow demon", 150);
        public Enemy mob2 = new("Wild centaur", 120);
        public RunestoneCircle() : base("Runestone circle", new Enemy("The Mighty Mage", 300)){}
        public override Enemy RandomMobSpawn()
        {
            Enemy randomMob = RandomMob(mob1, mob2);
            PrintEnemyEntry("from behind the runestone", randomMob);
            return randomMob;
        }
    }
}
