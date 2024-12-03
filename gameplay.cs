using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQL
{
    internal class gameplay
    {
        public void game()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--BELOW ARE SOME CLASSIFICATIONS FOR HOW YOU PLAY A FRAME--");
            Thread.Sleep(2000);

            bool isRunning = true;
            string gameChoice = string.Empty;

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ENTER A NUMBER TO READ THE DESCRIPTION (1-3): ");
                if (!int.TryParse(Console.ReadLine(), out int choi))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID INPUT. PLEASE ENTER A NUMBER.");
                    continue;
                }

                switch (choi)
                {
                    case 1: // Weapon platform
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("WEAPONPLATFORMS ARE FRAMES THAT HAVE MASTERED THE ART OF WEAPONRY");
                        if (ConfirmChoice())
                        {
                            gameChoice = "WEAPONPLATFORM";
                            isRunning = false;
                        }
                        break;

                    case 2: // Caster
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("CASTERS RELY ON THEIR ABILITIES TO DEAL DAMAGE");
                        if (ConfirmChoice())
                        {
                            gameChoice = "CASTER";
                            isRunning = false;
                        }
                        break;

                    case 3: // Warframe
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("WARFRAMES ARE BALANCED IN BOTH WEAPONRY AND ABILITIES");
                        if (ConfirmChoice())
                        {
                            gameChoice = "WARFRAME";
                            isRunning = false;
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("INVALID INPUT. TRY AGAIN.");
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"YOU SELECTED: {gameChoice}");
        }

        public bool ConfirmChoice()
        {
            Console.Write("CONFIRM CHOICE?(Y/N): ");
            string response = Console.ReadLine()?.ToUpper();
            return response == "Y";
        }
    }
}

