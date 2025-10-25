using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class ValidInput
    {
        internal static void ValidInputUI(int i_Min, int i_Max, out int io_InputInt)
        {
            bool tryAgain = true;
            io_InputInt = 0;

            while (tryAgain)
            {
                try
                {
                    string inputStr = Console.ReadLine();
                    ValidInputNumber.IntValid(inputStr, i_Min, i_Max, out io_InputInt);
                    tryAgain = false;
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
        }
    }
}
