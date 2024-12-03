using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    internal class Rate110
    {
        public int rate()
        {
            int ratA = 0;bool isValid = false; while (!isValid)     {Console.Write("\nHOW WOULD YOU RATE THE FRAME (1 to 10): ");  string input = Console.ReadLine();   if (int.TryParse(input, out ratA)){if (ratA >= 1 && ratA <= 10)  {isValid = true;  }  else  {Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("PLEASE ENTER A RATING THAT SATISFY THE PROMPT."); }}  else  {Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");}}       return ratA;
        }
    }
}
