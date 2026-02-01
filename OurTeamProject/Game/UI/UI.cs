using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Game.UI
{
    internal class UIclass
    {
        public static void FinalDialogue()
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Skip final dialogue?\n1 - Yes\n2 - No");
                choice = Console.ReadLine();
                if (choice == "1")
                    return;
                else if (choice == "2")
                    break;
                else
                    continue;
            } while (true);

            Console.Clear();
            Console.WriteLine("An old sage met you at the border.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Old sage: \"You have packed your bags, traveler.");
            Thread.Sleep(2000);
            Console.WriteLine("\tYour eyes are fixed on the horizon,");
            Thread.Sleep(2000);
            Console.WriteLine("\tbut are your hands ready for what lurks in the shadows?\"\n");
            Thread.Sleep(2000);

            Console.WriteLine("You: \"I have practiced, Elder.");
            Thread.Sleep(2000);
            Console.WriteLine("\tMy blade is sharp, and my resolve is firm.");
            Thread.Sleep(1400);
            Console.WriteLine("\tThese lands have grown too small for me.\"\n");
            Thread.Sleep(2000);

            Console.WriteLine("Old sage: \"Face me.");
            Thread.Sleep(2000);
            Console.WriteLine("If you can overcome my reflection, the path shall open.");
            Thread.Sleep(1400);
            Console.WriteLine("If not — return to your plow, for death beyond these borders knows no respect.\"");
            Thread.Sleep(2000);
        }
        public static void AfterWinDialogue()
        {
            Console.WriteLine("Old sage: (Breathing heavily) \"You have bested an old teacher,");
            Thread.Sleep(2000);
            Console.WriteLine("\tbut remember: the monsters beyond these woods will not wait for your move.");
            Thread.Sleep(1500);
            Console.WriteLine("\tI see now that you have the strength to survive.");
            Thread.Sleep(1500);
            Console.WriteLine("\tBut do you have the heart to remain human in the chaos?");
            Thread.Sleep(2000);
            Console.WriteLine("\tThat will be your true trial.\"\n");
            Thread.Sleep(3000);

            Console.WriteLine("You: \"I understand. My journey begins now.\"");
            Thread.Sleep(3000);
        }
    }
}
